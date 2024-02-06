using BidCalculation.Domain.Models;

namespace BidCalculationApi.Services.BasicFees
{
    public class BasicFeeFakeDataService : IBasicFeeService
    {
        private BasicFee basicFee;
        public BasicFeeFakeDataService()
        {
            basicFee = new BasicFee
            {
                Id = 1,
                BasicUserFeePercentage = 10
            };
        }

        public Task<BasicFee> GetBasicFeeAsync()
        {
            return Task.FromResult(basicFee);
        }
    }
}