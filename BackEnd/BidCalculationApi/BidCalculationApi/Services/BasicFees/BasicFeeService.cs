using BidCalculation.Domain.Models;
using BidCalculationApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BidCalculationApi.Services.BasicFees
{
    public class BasicFeeService : IBasicFeeService
    {
        private readonly BidCalculationDbContext bidCalculationDbContext;

        public BasicFeeService(BidCalculationDbContext bidCalculationDbContext)
        {
            this.bidCalculationDbContext = bidCalculationDbContext;
        }
        public async Task<BasicFee> GetBasicFeeAsync()
        {
            return await bidCalculationDbContext.BasicFees.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}