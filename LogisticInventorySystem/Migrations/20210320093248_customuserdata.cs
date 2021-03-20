using Microsoft.EntityFrameworkCore.Migrations;

namespace LogisticInventorySystem.Migrations
{
    public partial class customuserdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffName",
                table: "AspNetUsers");
        }
    }
}
