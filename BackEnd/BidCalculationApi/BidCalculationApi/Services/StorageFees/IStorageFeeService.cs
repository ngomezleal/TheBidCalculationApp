using BidCalculation.Domain.Models;

namespace BidCalculationApi.Services.StorageFees
{
    public interface IStorageFeeService
    {
        Task<StorageFee> GetStorageFeeAsync();
    }
}