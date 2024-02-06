using System;

namespace BidCalculation.Domain.Dtos
{
    public class SellerSpecialFeeDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal SpecialFeePercentage { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
