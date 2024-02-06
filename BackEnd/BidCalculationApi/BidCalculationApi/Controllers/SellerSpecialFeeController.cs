using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Services;
using BidCalculationApi.Services.SpecialFees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace BidCalculationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OutputCache(PolicyName = "bid")]
    public class SellerSpecialFeeController : ControllerBase
    {
        private readonly ISellerSpecialFeeService sellerSpecialFeeService;

        public SellerSpecialFeeController(ISellerSpecialFeeService sellerSpecialFeeService)
        {
            this.sellerSpecialFeeService = sellerSpecialFeeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<SellerSpecialFeeDto>>>> GetAllSellerSpecialFee()
        {
            var result = await sellerSpecialFeeService.GetAllSellerSpecialFeeAsync();
            return Ok(result);
        }
    }
}
