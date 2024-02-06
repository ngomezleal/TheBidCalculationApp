using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Services;
using BidCalculationApi.Services.AssociationFees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace BidCalculationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OutputCache(PolicyName = "bid")]
    public class AssociationFeeController : ControllerBase
    {
        private readonly IAssociationFeeService associationFeeService;

        public AssociationFeeController(IAssociationFeeService associationFeeService)
        {
            this.associationFeeService = associationFeeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<AssociationFeeDto>>>> GetAllAssociationFee()
        {
            var result = await associationFeeService.GetAllAssociationFeesAsync();
            return Ok(result);
        }
    }
}