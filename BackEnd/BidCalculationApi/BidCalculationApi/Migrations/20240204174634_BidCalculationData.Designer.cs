﻿// <auto-generated />
using BidCalculationApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BidCalculationApi.Migrations
{
    [DbContext(typeof(BidCalculationDbContext))]
    [Migration("20240204174634_BidCalculationData")]
    partial class BidCalculationData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BidCalculation.Domain.Models.AssociationFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RangeFrom")
                        .HasPrecision(36)
                        .HasColumnType("decimal(36,0)");

                    b.Property<decimal>("RangeUntil")
                        .HasPrecision(36, 6)
                        .HasColumnType("decimal(36,6)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("AssociationFees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "$5 for an amount between $1 and $500",
                            RangeFrom = 1m,
                            RangeUntil = 500m,
                            TotalAmount = 5m
                        },
                        new
                        {
                            Id = 2,
                            Description = "$10 for an amount greater than $500 up to $1000",
                            RangeFrom = 500m,
                            RangeUntil = 1000m,
                            TotalAmount = 10m
                        },
                        new
                        {
                            Id = 3,
                            Description = "$15 for an amount greater than $1000 up to $3000",
                            RangeFrom = 1000m,
                            RangeUntil = 3000m,
                            TotalAmount = 15m
                        },
                        new
                        {
                            Id = 4,
                            Description = "$20 for an amount over $3000",
                            RangeFrom = 3000m,
                            RangeUntil = 79228162514264337593543950335m,
                            TotalAmount = 20m
                        });
                });

            modelBuilder.Entity("BidCalculation.Domain.Models.BasicFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasicUserFeePercentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("BasicFees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BasicUserFeePercentage = 10m
                        });
                });

            modelBuilder.Entity("BidCalculation.Domain.Models.SellerSpecialFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SpecialFeePercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SellerSpecialFees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Common car: 2% of the vehicle price",
                            SpecialFeePercentage = 2m,
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Luxury car: 4% of the vehicle price",
                            SpecialFeePercentage = 4m,
                            VehicleTypeId = 2
                        });
                });

            modelBuilder.Entity("BidCalculation.Domain.Models.StorageFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("FixedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("StorageFees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FixedAmount = 100m
                        });
                });

            modelBuilder.Entity("BidCalculation.Domain.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RangeFrom")
                        .HasColumnType("int");

                    b.Property<int>("RangeUntil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Common",
                            RangeFrom = 10,
                            RangeUntil = 50
                        },
                        new
                        {
                            Id = 2,
                            Name = "Luxury",
                            RangeFrom = 25,
                            RangeUntil = 200
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
