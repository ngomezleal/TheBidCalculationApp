using AutoMapper;
using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Models;
using BidCalculation.Domain.Services;
using BidCalculationApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BidCalculationApi.Services.SpecialFees
{
    public class SellerSpecialFeeService : ISellerSpecialFeeService
    {
        private readonly BidCalculationDbContext bidCalculationDbContext;
        private readonly IMapper mapper;

        public SellerSpecialFeeService(BidCalculationDbContext bidCalculationDbContext, IMapper mapper)
        {
            this.bidCalculationDbContext = bidCalculationDbContext;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<SellerSpecialFeeDto>>> GetAllSellerSpecialFeeAsync()
        {
            var sellerSpecialFee = await bidCalculationDbContext.SellerSpecialFees.AsNoTracking().ToListAsync();
            var response = new ServiceResponse<List<SellerSpecialFeeDto>>()
            {
                Data = mapper.Map<List<SellerSpecialFeeDto>>(sellerSpecialFee)
            };
            return response;
        }

        public async Task<SellerSpecialFee> GetSellerSpecialFeeByVehicleIdAsync(int id)
        {
            return await bidCalculationDbContext.SellerSpecialFees.AsNoTracking().FirstOrDefaultAsync(sf => sf.VehicleTypeId == id);
        }
    }
}