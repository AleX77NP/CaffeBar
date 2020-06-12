using Microsoft.EntityFrameworkCore.Migrations;

namespace CaffeBar.Migrations
{
    public partial class NewXCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Available",
                table: "Drinks",
                nullable: false,
                defaultValue: 100);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Drinks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TotalDrink",
                table: "Drinks",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "TotalDrink",
                table: "Drinks");
        }
    }
}
