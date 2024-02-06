using BidCalculationApi.Services.BasicFees;
using BidCalculationApi.Services.VehicleTypes;
using BidCalculationApi.Helpers;
using BidCalculationApi.Services.SpecialFees;
using BidCalculationApi.Services.AssociationFees;
using BidCalculationApi.Services.StorageFees;
using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Services;

namespace BidCalculationApi.Services.Bid
{
    public class BidCalculationService : IBidCalculationService
    {
        private readonly IBasicFeeService basicFeeService;
        private readonly IVehicleTypeService vehicleTypeService;
        private readonly ISellerSpecialFeeService sellerSpecialFeeService;
        private readonly IAssociationFeeService associationFeeService;
        private readonly IStorageFeeService storageFeeService;

        public BidCalculationService(IBasicFeeService basicFeeService, IVehicleTypeService vehicleTypeService, 
            ISellerSpecialFeeService sellerSpecialFeeService, IAssociationFeeService associationFeeService, 
            IStorageFeeService storageFeeService)
        {
            this.basicFeeService = basicFeeService;
            this.vehicleTypeService = vehicleTypeService;
            this.sellerSpecialFeeService = sellerSpecialFeeService;
            this.associationFeeService = associationFeeService;
            this.storageFeeService = storageFeeService;
        }
        public async Task<ServiceResponse<BidCalculationDto>> BidCalculation(decimal vechicleBasePrice, int vehicleTypeId)
        {
            var response = new ServiceResponse<BidCalculationDto>();
            decimal vSpecialFee = 0.0M, vAssociationFee = 0.0M, vTotalFee = 0.0M;
            
            //"Basic" user fee
            var basicFee = await basicFeeService.GetBasicFeeAsync();
            var basicUserFee = (vechicleBasePrice * basicFee.BasicUserFeePercentage) / 100;

            //Storage fee
            var storageFee = await storageFeeService.GetStorageFeeAsync();

            //Select Vehicle type
            var vType = await vehicleTypeService.GetVehicleTypeByIdAsync(vehicleTypeId);
            if (vType is not null)
            {
                if (!GenericMethods.Between(basicUserFee, vType.RangeFrom, vType.RangeUntil))
                    basicUserFee = GenericMethods.NearestValue(basicUserFee, vType.RangeFrom, vType.RangeUntil);

                //The seller's "special" fee
                var sFee = await sellerSpecialFeeService.GetSellerSpecialFeeByVehicleIdAsync(vType.Id);
                if (sFee is not null)
                    vSpecialFee = (vechicleBasePrice * sFee.SpecialFeePercentage) / 100;

                //Costs for the "association" based on the price of the vehicle
                var associationFees = await associationFeeService.GetAllAssociationFeesAsync();
                var associationFeeId = 0;
                if (associationFees.Success)
                {
                    foreach (var item in associationFees.Data)
                    {
                        if (GenericMethods.Between(vechicleBasePrice, item.RangeFrom, item.RangeUntil))
                        {
                            vAssociationFee = item.TotalAmount;
                            associationFeeId = item.Id;
                            break;
                        }
                    }
                }

                //"Total" fee 
                vTotalFee = vechicleBasePrice + basicUserFee + vSpecialFee + vAssociationFee + storageFee.FixedAmount;
                response.Data = new BidCalculationDto
                {
                    VehicleBasePrice = vechicleBasePrice,
                    BasicUserFee = basicUserFee,
                    SpecialFee = vSpecialFee,
                    SpecialFeeId = sFee.Id,
                    AssociationFee = vAssociationFee,
                    AssociationFeeId = associationFeeId,
                    FixedAmount = storageFee.FixedAmount,
                    TotalFee = vTotalFee
                };
            }
            else
            {
                response.Success = false;
                response.Message = "Sorry, but this vehicle type doesn't exist!";
            }
            return response;
        }
    }
}