using BidCalculation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BidCalculationApi.Persistence
{
    public class BidCalculationDbContext : DbContext
    {
        public BidCalculationDbContext(DbContextOptions<BidCalculationDbContext> options) 
            : base(options)
        {}
        public BidCalculationDbContext()
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BasicFee>().HasData(
                new BasicFee
                {
                    Id = 1,
                    BasicUserFeePercentage = 10
                });

            modelBuilder.Entity<VehicleType>().HasData(
                 new VehicleType
                 {
                     Id = 1,
                     Name = "Common",
                     RangeFrom = 10,
                     RangeUntil = 50
                 },
                 new VehicleType
                 {
                     Id = 2,
                     Name = "Luxury",
                     RangeFrom = 25,
                     RangeUntil = 200
                 });

            modelBuilder.Entity<SellerSpecialFee>().HasData(
                new SellerSpecialFee
                {
                    Id = 1,
                    Description = "Common car: 2% of the vehicle price",
                    SpecialFeePercentage = 2,
                    VehicleTypeId = 1
                },
                new SellerSpecialFee
                {
                    Id = 2,
                    Description = "Luxury car: 4% of the vehicle price",
                    SpecialFeePercentage = 4,
                    VehicleTypeId = 2
                });

            modelBuilder.Entity<AssociationFee>().Property(obj => obj.RangeFrom).HasPrecision(36, 0);
            modelBuilder.Entity<AssociationFee>().Property(obj => obj.RangeUntil).HasPrecision(36, 6);
            modelBuilder.Entity<AssociationFee>().HasData(
                new AssociationFee
                {
                    Id = 1,
                    Description = "5 for an amount between 1 and 500",
                    RangeFrom = 1,
                    RangeUntil = 500,
                    TotalAmount = 5
                },
                new AssociationFee
                {
                    Id = 2,
                    Description = "10 for an amount greater than 500 up to 1000",
                    RangeFrom = 500,
                    RangeUntil = 1000,
                    TotalAmount = 10
                },
                new AssociationFee
                {
                    Id = 3,
                    Description = "15 for an amount greater than 1000 up to 3000",
                    RangeFrom = 1000,
                    RangeUntil = 3000,
                    TotalAmount = 15
                },
                new AssociationFee
                {
                    Id = 4,
                    Description = "20 for an amount over 3000",
                    RangeFrom = 3000,
                    RangeUntil = decimal.MaxValue,
                    TotalAmount = 20
                });

            modelBuilder.Entity<StorageFee>().HasData(
                new StorageFee
                {
                    Id = 1,
                    FixedAmount = 100
                });
        }

        public virtual DbSet<BasicFee> BasicFees { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<SellerSpecialFee> SellerSpecialFees { get; set; }
        public virtual DbSet<AssociationFee> AssociationFees { get; set; }
        public virtual DbSet<StorageFee> StorageFees { get; set; }
    }
}