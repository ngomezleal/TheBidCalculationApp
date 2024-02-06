using System;

namespace BidCalculation.Domain.Models
{
    public class AssociationFee
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal RangeFrom { get; set; }
        public decimal RangeUntil { get; set; }
        public decimal TotalAmount { get; set; }
    }
}