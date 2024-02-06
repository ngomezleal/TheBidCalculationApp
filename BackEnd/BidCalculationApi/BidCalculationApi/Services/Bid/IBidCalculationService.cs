using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Services;

namespace BidCalculationApi.Services.Bid
{
    public interface IBidCalculationService
    {
        Task<ServiceResponse<BidCalculationDto>> BidCalculation(decimal vechicleBasePrice, int vehicleTypeId);
    }
}