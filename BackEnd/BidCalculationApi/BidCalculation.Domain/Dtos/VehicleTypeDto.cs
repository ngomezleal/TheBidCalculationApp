using System;

namespace BidCalculation.Domain.Dtos
{
    public class VehicleTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int RangeFrom { get; set; }
        public int RangeUntil { get; set; }
    }
}
