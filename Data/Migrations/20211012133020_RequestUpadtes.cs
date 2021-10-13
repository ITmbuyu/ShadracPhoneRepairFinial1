using Microsoft.EntityFrameworkCore.Migrations;

namespace ShadracPhoneRepairFinial1.Data.Migrations
{
    public partial class RequestUpadtes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceCapacity",
                table: "WalkInRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceColors",
                table: "WalkInRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceNames",
                table: "WalkInRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceProblems",
                table: "WalkInRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceCapacity",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceColors",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceNames",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceProblems",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceCapacity",
                table: "WalkInRequests");

            migrationBuilder.DropColumn(
                name: "DeviceColors",
                table: "WalkInRequests");

            migrationBuilder.DropColumn(
                name: "DeviceNames",
                table: "WalkInRequests");

            migrationBuilder.DropColumn(
                name: "DeviceProblems",
                table: "WalkInRequests");

            migrationBuilder.DropColumn(
                name: "DeviceCapacity",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeviceColors",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeviceNames",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeviceProblems",
                table: "Requests");
        }
    }
}
