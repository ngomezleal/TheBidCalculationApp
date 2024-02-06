using BidCalculation.Domain.Models;
using BidCalculationApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BidCalculationApi.Services.StorageFees
{
    public class StorageFeeService : IStorageFeeService
    {
        private readonly BidCalculationDbContext bidCalculationDbContext;

        public StorageFeeService(BidCalculationDbContext bidCalculationDbContext)
        {
            this.bidCalculationDbContext = bidCalculationDbContext;
        }

        public async Task<StorageFee> GetStorageFeeAsync()
        {
            return await bidCalculationDbContext.StorageFees.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}