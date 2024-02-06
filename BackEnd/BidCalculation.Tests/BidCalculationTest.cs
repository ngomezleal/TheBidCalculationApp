using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Services;
using BidCalculationApi.Services.AssociationFees;
using BidCalculationApi.Services.BasicFees;
using BidCalculationApi.Services.Bid;
using BidCalculationApi.Services.SpecialFees;
using BidCalculationApi.Services.StorageFees;
using BidCalculationApi.Services.VehicleTypes;
using Moq;

namespace BidCalculation.Tests
{
    public class BidCalculationTest
    {
        private readonly Mock<IBasicFeeService> mockBasicFeeService;
        private readonly Mock<IVehicleTypeService> mockVehicleTypeCommonService;
        private readonly Mock<IVehicleTypeService> mockVehicleTypeLuxuryService;
        private readonly Mock<ISellerSpecialFeeService> mockSellerSpecialFeeCommonService;
        private readonly Mock<ISellerSpecialFeeService> mockSellerSpecialFeeLuxuryService;
        private readonly Mock<IStorageFeeService> mockStorageFeeService;
        private readonly Mock<IAssociationFeeService> mockAssociationFeeService;

        public BidCalculationTest()
        {
            mockBasicFeeService = new Mock<IBasicFeeService>();
            mockBasicFeeService.Setup(x => x.GetBasicFeeAsync())
                                .ReturnsAsync(new Domain.Models.BasicFee()
                                {
                                    Id = 1,
                                    BasicUserFeePercentage = 10
                                });

            mockStorageFeeService = new Mock<IStorageFeeService>();
            mockStorageFeeService.Setup(x => x.GetStorageFeeAsync())
                                .ReturnsAsync(new Domain.Models.StorageFee()
                                {
                                    Id = 1,
                                    FixedAmount = 100
                                });

            mockVehicleTypeCommonService = new Mock<IVehicleTypeService>();
            mockVehicleTypeCommonService.Setup(x => x.GetVehicleTypeByIdAsync(1))
                                .ReturnsAsync(new Domain.Models.VehicleType()
                                {
                                    Id = 1,
                                    Name = "Common",
                                    RangeFrom = 10,
                                    RangeUntil = 50
                                });

            mockVehicleTypeLuxuryService = new Mock<IVehicleTypeService>();
            mockVehicleTypeLuxuryService.Setup(x => x.GetVehicleTypeByIdAsync(2))
                                .ReturnsAsync(new Domain.Models.VehicleType()
                                {
                                    Id = 2,
                                    Name = "Luxury",
                                    RangeFrom = 25,
                                    RangeUntil = 200
                                });

            mockSellerSpecialFeeCommonService = new Mock<ISellerSpecialFeeService>();
            mockSellerSpecialFeeCommonService.Setup(x => x.GetSellerSpecialFeeByVehicleIdAsync(1))
                                .ReturnsAsync(new Domain.Models.SellerSpecialFee()
                                {
                                    Id = 1,
                                    Description = "Common car: 2% of the vehicle price",
                                    SpecialFeePercentage = 2,
                                    VehicleTypeId = 1
                                });

            mockSellerSpecialFeeLuxuryService = new Mock<ISellerSpecialFeeService>();
            mockSellerSpecialFeeLuxuryService.Setup(x => x.GetSellerSpecialFeeByVehicleIdAsync(2))
                                .ReturnsAsync(new Domain.Models.SellerSpecialFee()
                                {
                                    Id = 2,
                                    Description = "Luxury car: 4% of the vehicle price",
                                    SpecialFeePercentage = 4,
                                    VehicleTypeId = 2
                                });

            mockAssociationFeeService = new Mock<IAssociationFeeService>();
            mockAssociationFeeService.Setup(x => x.GetAllAssociationFeesAsync())
                                .ReturnsAsync(new Domain.Services.ServiceResponse<List<AssociationFeeDto>>()
                                {
                                    Data = new List<AssociationFeeDto>()
                                    {
                                       new AssociationFeeDto
                                    {
                                        Id = 1,
                                        Description = "5 for an amount between 1 and 500",
                                        RangeFrom = 1,
                                        RangeUntil = 500,
                                        TotalAmount = 5
                                    },
                                    new AssociationFeeDto
                                    {
                                        Id = 2,
                                        Description = "10 for an amount greater than 500 up to 1000",
                                        RangeFrom = 500,
                                        RangeUntil = 1000,
                                        TotalAmount = 10
                                    },
                                    new AssociationFeeDto
                                    {
                                        Id = 3,
                                        Description = "15 for an amount greater than 1000 up to 3000",
                                        RangeFrom = 1000,
                                        RangeUntil = 3000,
                                        TotalAmount = 15
                                    },
                                    new AssociationFeeDto
                                    {
                                        Id = 4,
                                        Description = "20 for an amount over 3000",
                                        RangeFrom = 3000,
                                        RangeUntil = decimal.MaxValue,
                                        TotalAmount = 20
                                    }}
                                });
        }

        [Fact]
        public async void BidCalculation_VehiclePrice1000_Common()
        {
            //Arrange
            var bidCalculationService = new BidCalculationService(mockBasicFeeService.Object,
                mockVehicleTypeCommonService.Object, mockSellerSpecialFeeCommonService.Object, mockAssociationFeeService.Object,
                mockStorageFeeService.Object);

            //Act
            var result = await bidCalculationService.BidCalculation(1000, 1);

            //Assert
            Assert.True(result.Data.TotalFee == 1180.00M);
            Assert.IsType<ServiceResponse<BidCalculationDto>>(result);
        }

        [Fact]
        public async void BidCalculation_VehiclePrice398_Common()
        {
            //Arrange
            var bidCalculationService = new BidCalculationService(mockBasicFeeService.Object,
                mockVehicleTypeCommonService.Object, mockSellerSpecialFeeCommonService.Object, mockAssociationFeeService.Object,
                mockStorageFeeService.Object);

            //Act
            var result = await bidCalculationService.BidCalculation(398, 1);

            //Assert
            Assert.True(result.Data.TotalFee == 550.76M);
            Assert.IsType<ServiceResponse<BidCalculationDto>>(result);
        }

        [Fact]
        public async void BidCalculation_VehiclePrice1000000_Luxury()
        {
            //Arrange
            var bidCalculationService = new BidCalculationService(mockBasicFeeService.Object,
                mockVehicleTypeLuxuryService.Object, mockSellerSpecialFeeLuxuryService.Object, mockAssociationFeeService.Object,
                mockStorageFeeService.Object);

            //Act
            var result = await bidCalculationService.BidCalculation(1000000, 2);

            //Assert
            Assert.True(result.Data.TotalFee == 1040320.00M);
            Assert.IsType<ServiceResponse<BidCalculationDto>>(result);
        }
    }
}