using Microsoft.EntityFrameworkCore.Migrations;

namespace CaffeBar.Migrations
{
    public partial class GuestsThird : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReservationTime",
                table: "Guests",
                maxLength: 50,
                nullable: false,
                defaultValue: "No time",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ReservationName",
                table: "Guests",
                maxLength: 25,
                nullable: false,
                defaultValue: "No name",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReservationTime",
                table: "Guests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldDefaultValue: "No time");

            migrationBuilder.AlterColumn<string>(
                name: "ReservationName",
                table: "Guests",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldDefaultValue: "No name");
        }
    }
}
