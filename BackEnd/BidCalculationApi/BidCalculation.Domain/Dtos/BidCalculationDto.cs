using System;

namespace BidCalculation.Domain.Dtos
{
    public class BidCalculationDto
    {
        public decimal VehicleBasePrice { get; set; }
        public decimal BasicUserFee { get; set; }
        public decimal SpecialFee { get; set; }
        public int SpecialFeeId { get; set; }
        public decimal AssociationFee { get; set; }
        public int AssociationFeeId { get; set; }
        public decimal FixedAmount { get; set; }
        public decimal TotalFee { get; set; }
    }
}
