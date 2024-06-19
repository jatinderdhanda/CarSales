using System;
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
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manufacture_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registration_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuel_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_detials", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    car_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    confirmed_on_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rejected_on_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    completed_on_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cancelled_on_utc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.id);
                    table.ForeignKey(
                        name: "FK_booking_car_detials_car_id",
                        column: x => x.car_id,
                        principalTable: "car_detials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_booking_car_id",
                table: "booking",
                column: "car_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "car_detials");
        }
    }
}
