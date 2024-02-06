using System;

namespace BidCalculation.Domain.Models
{
    public class SellerSpecialFee
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal SpecialFeePercentage { get; set; }
        public int VehicleTypeId { get; set; }
    }
}