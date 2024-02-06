using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BidCalculationApi.Migrations
{
    /// <inheritdoc />
    public partial class BidCalculationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssociationFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RangeFrom = table.Column<decimal>(type: "decimal(36,0)", precision: 36, scale: 0, nullable: false),
                    RangeUntil = table.Column<decimal>(type: "decimal(36,6)", precision: 36, scale: 6, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasicFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicUserFeePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellerSpecialFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialFeePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerSpecialFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FixedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RangeFrom = table.Column<int>(type: "int", nullable: false),
                    RangeUntil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AssociationFees",
                columns: new[] { "Id", "Description", "RangeFrom", "RangeUntil", "TotalAmount" },
                values: new object[,]
                {
                    { 1, "$5 for an amount between $1 and $500", 1m, 500m, 5m },
                    { 2, "$10 for an amount greater than $500 up to $1000", 500m, 1000m, 10m },
                    { 3, "$15 for an amount greater than $1000 up to $3000", 1000m, 3000m, 15m },
                    { 4, "$20 for an amount over $3000", 3000m, 79228162514264337593543950335m, 20m }
                });

            migrationBuilder.InsertData(
                table: "BasicFees",
                columns: new[] { "Id", "BasicUserFeePercentage" },
                values: new object[] { 1, 10m });

            migrationBuilder.InsertData(
                table: "SellerSpecialFees",
                columns: new[] { "Id", "Description", "SpecialFeePercentage", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, "Common car: 2% of the vehicle price", 2m, 1 },
                    { 2, "Luxury car: 4% of the vehicle price", 4m, 2 }
                });

            migrationBuilder.InsertData(
                table: "StorageFees",
                columns: new[] { "Id", "FixedAmount" },
                values: new object[] { 1, 100m });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Name", "RangeFrom", "RangeUntil" },
                values: new object[,]
                {
                    { 1, "Common", 10, 50 },
                    { 2, "Luxury", 25, 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociationFees");

            migrationBuilder.DropTable(
                name: "BasicFees");

            migrationBuilder.DropTable(
                name: "SellerSpecialFees");

            migrationBuilder.DropTable(
                name: "StorageFees");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
