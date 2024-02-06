using AutoMapper;
using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Models;
using BidCalculation.Domain.Services;

namespace BidCalculationApi.Services.AssociationFees
{
    public class AssociationFeeFakeDataService : IAssociationFeeService
    {
        private readonly IMapper mapper;
        List<AssociationFee> associationFees;
        public AssociationFeeFakeDataService(IMapper mapper)
        {
            associationFees = new List<AssociationFee>()
            {
                new AssociationFee
                {
                    Id = 1,
                    Description = "5 for an amount between 1 and 500",
                    RangeFrom = 1,
                    RangeUntil = 500,
                    TotalAmount = 5
                },
                new AssociationFee
                {
                    Id = 2,
                    Description = "10 for an amount greater than 500 up to 1000",
                    RangeFrom = 500,
                    RangeUntil = 1000,
                    TotalAmount = 10
                },
                new AssociationFee
                {
                    Id = 3,
                    Description = "15 for an amount greater than 1000 up to 3000",
                    RangeFrom = 1000,
                    RangeUntil = 3000,
                    TotalAmount = 15
                },
                new AssociationFee
                {
                    Id = 4,
                    Description = "20 for an amount over 3000",
                    RangeFrom = 3000,
                    RangeUntil = decimal.MaxValue,
                    TotalAmount = 20
                }
            };
            this.mapper = mapper;
        }

        public Task<ServiceResponse<List<AssociationFeeDto>>> GetAllAssociationFeesAsync()
        {
            var associationFee = associationFees.ToList();
            var response = new ServiceResponse<List<AssociationFeeDto>>()
            {
                Data = mapper.Map<List<AssociationFeeDto>>(associationFee)
            };
            return Task.FromResult(response);
        }
    }
}