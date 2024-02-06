using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Models;
using BidCalculation.Domain.Services;

namespace BidCalculationApi.Services.SpecialFees
{
    public interface ISellerSpecialFeeService
    {
        Task<SellerSpecialFee> GetSellerSpecialFeeByVehicleIdAsync(int id);
        Task<ServiceResponse<List<SellerSpecialFeeDto>>> GetAllSellerSpecialFeeAsync();
    }
}