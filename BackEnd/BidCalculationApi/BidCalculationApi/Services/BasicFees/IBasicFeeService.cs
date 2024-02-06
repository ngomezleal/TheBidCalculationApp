using BidCalculation.Domain.Models;

namespace BidCalculationApi.Services.BasicFees
{
    public interface IBasicFeeService
    {
        Task<BasicFee> GetBasicFeeAsync();
    }
}