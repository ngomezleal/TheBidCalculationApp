using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Services;
using BidCalculationApi.Services.Bid;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidCalculationController : ControllerBase
    {
        private readonly IBidCalculationService bidCalculationService;

        public BidCalculationController(IBidCalculationService bidCalculationService)
        {
            this.bidCalculationService = bidCalculationService;
        }

        [HttpGet("{basePrice}/{vehicleTypeId:int}")]
        public async Task<ActionResult<ServiceResponse<BidCalculationDto>>> BidCalculation(decimal basePrice, int vehicleTypeId)
        {
            var result = await bidCalculationService.BidCalculation(basePrice, vehicleTypeId);
            return Ok(result);
        }
    }
}