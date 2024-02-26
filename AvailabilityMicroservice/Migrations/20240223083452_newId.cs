using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvailabilityMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class newId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    AvailableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => new { x.EmployeeId, x.AvailableDate, x.AvailableTime });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availability");
        }
    }
}
