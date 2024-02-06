using AutoMapper;
using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Services;
using BidCalculationApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BidCalculationApi.Services.AssociationFees
{
    public class AssociationFeeService : IAssociationFeeService
    {
        private readonly BidCalculationDbContext bidCalculationDbContext;
        private readonly IMapper mapper;

        public AssociationFeeService(BidCalculationDbContext bidCalculationDbContext, IMapper mapper)
        {
            this.bidCalculationDbContext = bidCalculationDbContext;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<AssociationFeeDto>>> GetAllAssociationFeesAsync()
        {
            var associationFee = await bidCalculationDbContext.AssociationFees.AsNoTracking().ToListAsync();
            var response = new ServiceResponse<List<AssociationFeeDto>>()
            {
                Data = mapper.Map<List<AssociationFeeDto>>(associationFee)
            };
            return response;
        }
    }
}