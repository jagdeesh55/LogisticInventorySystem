using Microsoft.EntityFrameworkCore.Migrations;

namespace LogisticInventorySystem.Migrations.LogisticInventorySystemItem
{
    public partial class itemdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "Item",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "Item");
        }
    }
}
