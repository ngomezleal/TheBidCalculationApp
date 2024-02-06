using AutoMapper;
using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Models;
using BidCalculation.Domain.Services;
using BidCalculationApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BidCalculationApi.Services.VehicleTypes
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly BidCalculationDbContext bidCalculationDbContext;
        private readonly IMapper mapper;

        public VehicleTypeService(BidCalculationDbContext bidCalculationDbContext, IMapper mapper)
        {
            this.bidCalculationDbContext = bidCalculationDbContext;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<VehicleTypeDto>>> GetAllVehicleTypesAsync()
        {
            var vehicleTypes = await bidCalculationDbContext.VehicleTypes.AsNoTracking().ToListAsync();
            var response = new ServiceResponse<List<VehicleTypeDto>>()
            {
                Data = mapper.Map<List<VehicleTypeDto>>(vehicleTypes)
            };
            return response;
        }

        public async Task<VehicleType> GetVehicleTypeByIdAsync(int id)
        {
            return await bidCalculationDbContext.VehicleTypes.AsNoTracking().FirstOrDefaultAsync(vt => vt.Id == id);
        }
    }
}