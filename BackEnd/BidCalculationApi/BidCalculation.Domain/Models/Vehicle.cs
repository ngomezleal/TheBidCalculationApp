using System;

namespace BidCalculation.Domain.Models
{
    public class Vehicle
    { 
        public int Id { get; set; }
        public string Plate { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public decimal BasePrice { get; set; }
    }
}