using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Services;

namespace BidCalculationApi.Services.AssociationFees
{
    public interface IAssociationFeeService
    {
        Task<ServiceResponse<List<AssociationFeeDto>>> GetAllAssociationFeesAsync();
    }
}