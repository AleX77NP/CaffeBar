using Microsoft.EntityFrameworkCore.Migrations;

namespace CaffeBar.Migrations
{
    public partial class EightCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BillDrink",
                table: "BillDrink");

            migrationBuilder.AddColumn<int>(
                name: "BillDrinkId",
                table: "BillDrink",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillDrink",
                table: "BillDrink",
                column: "BillDrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDrink_BillId",
                table: "BillDrink",
                column: "BillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BillDrink",
                table: "BillDrink");

            migrationBuilder.DropIndex(
                name: "IX_BillDrink_BillId",
                table: "BillDrink");

            migrationBuilder.DropColumn(
                name: "BillDrinkId",
                table: "BillDrink");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillDrink",
                table: "BillDrink",
                columns: new[] { "BillId", "DrinkId" });
        }
    }
}
