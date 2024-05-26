using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSales.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car_detials",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_manufacture_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_registration_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_detials", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car_detials");
        }
    }
}
