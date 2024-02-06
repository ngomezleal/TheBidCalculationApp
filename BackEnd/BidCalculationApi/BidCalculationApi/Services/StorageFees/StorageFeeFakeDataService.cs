using BidCalculation.Domain.Models;

namespace BidCalculationApi.Services.StorageFees
{
    public class StorageFeeFakeDataService : IStorageFeeService
    {
        private StorageFee storageFee;
        public StorageFeeFakeDataService()
        {
            storageFee = new StorageFee()
            {
                Id = 1,
                FixedAmount = 100
            };
        }
        public Task<StorageFee> GetStorageFeeAsync()
        {
            return Task.FromResult(storageFee);
        }
    }
}
