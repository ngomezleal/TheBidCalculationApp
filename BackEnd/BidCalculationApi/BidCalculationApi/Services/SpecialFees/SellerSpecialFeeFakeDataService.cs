using AutoMapper;
using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Models;
using BidCalculation.Domain.Services;

namespace BidCalculationApi.Services.SpecialFees
{
    public class SellerSpecialFeeFakeDataService : ISellerSpecialFeeService
    {
        private readonly IMapper mapper;
        private List<SellerSpecialFee> sellerSpecialFees;
        public SellerSpecialFeeFakeDataService(IMapper mapper)
        {
            sellerSpecialFees = new List<SellerSpecialFee>()
            {
                 new SellerSpecialFee
                {
                    Id = 1,
                    Description = "Common car: 2% of the vehicle price",
                    SpecialFeePercentage = 2,
                    VehicleTypeId = 1
                },
                new SellerSpecialFee
                {
                    Id = 2,
                    Description = "Luxury car: 4% of the vehicle price",
                    SpecialFeePercentage = 4,
                    VehicleTypeId = 2
                }
            };
            this.mapper = mapper;
        }

        public Task<ServiceResponse<List<SellerSpecialFeeDto>>> GetAllSellerSpecialFeeAsync()
        {
            var sellerSpecialFee = sellerSpecialFees.ToList();
            var response = new ServiceResponse<List<SellerSpecialFeeDto>>()
            {
                Data = mapper.Map<List<SellerSpecialFeeDto>>(sellerSpecialFee)
            };
            return Task.FromResult(response);
        }

        public Task<SellerSpecialFee> GetSellerSpecialFeeByVehicleIdAsync(int id)
        {
            var result = sellerSpecialFees.FirstOrDefault(sf => sf.VehicleTypeId == id);
            return Task.FromResult(result);
        }
    }
}
