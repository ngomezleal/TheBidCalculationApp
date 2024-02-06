using AutoMapper;
using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Models;
using BidCalculation.Domain.Services;

namespace BidCalculationApi.Services.VehicleTypes
{
    public class VehicleTypeFakeDataService : IVehicleTypeService
    {
        private readonly IMapper mapper;
        private List<VehicleType> vehicleType;
        public VehicleTypeFakeDataService(IMapper mapper)
        {
            vehicleType = new List<VehicleType>()
            {
                new VehicleType
                 {
                     Id = 1,
                     Name = "Common",
                     RangeFrom = 10,
                     RangeUntil = 50
                 },
                 new VehicleType
                 {
                     Id = 2,
                     Name = "Luxury",
                     RangeFrom = 25,
                     RangeUntil = 200
                 }
            };
            this.mapper = mapper;
        }

        public Task<ServiceResponse<List<VehicleTypeDto>>> GetAllVehicleTypesAsync()
        {
            var vehicleTypes = vehicleType.ToList();
            var response = new ServiceResponse<List<VehicleTypeDto>>()
            {
                Data = mapper.Map<List<VehicleTypeDto>>(vehicleTypes)
            };
            return Task.FromResult(response);
        }

        public Task<VehicleType> GetVehicleTypeByIdAsync(int id)
        {
            var result = vehicleType.FirstOrDefault(vt => vt.Id == id);
            return Task.FromResult(result);
        }
    }
}