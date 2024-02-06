using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Services;
using BidCalculationApi.Services.VehicleTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace BidCalculationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OutputCache(PolicyName = "bid")]
    public class VehicleTypesController : ControllerBase
    {
        private readonly IVehicleTypeService vehicleTypeService;

        public VehicleTypesController(IVehicleTypeService vehicleTypeService)
        {
            this.vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<VehicleTypeDto>>>> GetAllVehicleTypes()
        {
            var result = await vehicleTypeService.GetAllVehicleTypesAsync();
            return Ok(result);
        }
    }
}