using Microsoft.EntityFrameworkCore.Migrations;

namespace ShadracPhoneRepairFinial1.Data.Migrations
{
    public partial class extending : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aadress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aadress",
                table: "AspNetUsers");
        }
    }
}
