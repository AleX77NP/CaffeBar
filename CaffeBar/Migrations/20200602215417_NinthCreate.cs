using Microsoft.EntityFrameworkCore.Migrations;

namespace CaffeBar.Migrations
{
    public partial class NinthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDrink_Bills_BillId",
                table: "BillDrink");

            migrationBuilder.DropForeignKey(
                name: "FK_BillDrink_Drinks_DrinkId",
                table: "BillDrink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillDrink",
                table: "BillDrink");

            migrationBuilder.RenameTable(
                name: "BillDrink",
                newName: "BillDrinks");

            migrationBuilder.RenameIndex(
                name: "IX_BillDrink_DrinkId",
                table: "BillDrinks",
                newName: "IX_BillDrinks_DrinkId");

            migrationBuilder.RenameIndex(
                name: "IX_BillDrink_BillId",
                table: "BillDrinks",
                newName: "IX_BillDrinks_BillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillDrinks",
                table: "BillDrinks",
                column: "BillDrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDrinks_Bills_BillId",
                table: "BillDrinks",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDrinks_Drinks_DrinkId",
                table: "BillDrinks",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDrinks_Bills_BillId",
                table: "BillDrinks");

            migrationBuilder.DropForeignKey(
                name: "FK_BillDrinks_Drinks_DrinkId",
                table: "BillDrinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillDrinks",
                table: "BillDrinks");

            migrationBuilder.RenameTable(
                name: "BillDrinks",
                newName: "BillDrink");

            migrationBuilder.RenameIndex(
                name: "IX_BillDrinks_DrinkId",
                table: "BillDrink",
                newName: "IX_BillDrink_DrinkId");

            migrationBuilder.RenameIndex(
                name: "IX_BillDrinks_BillId",
                table: "BillDrink",
                newName: "IX_BillDrink_BillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillDrink",
                table: "BillDrink",
                column: "BillDrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDrink_Bills_BillId",
                table: "BillDrink",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDrink_Drinks_DrinkId",
                table: "BillDrink",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
