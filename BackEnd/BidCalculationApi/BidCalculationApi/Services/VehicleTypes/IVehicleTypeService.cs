using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Models;
using BidCalculation.Domain.Services;

namespace BidCalculationApi.Services.VehicleTypes
{
    public interface IVehicleTypeService
    {
        Task<VehicleType> GetVehicleTypeByIdAsync(int id);
        Task<ServiceResponse<List<VehicleTypeDto>>> GetAllVehicleTypesAsync();
    }
}