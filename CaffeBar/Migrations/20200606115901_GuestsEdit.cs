using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaffeBar.Migrations
{
    public partial class GuestsEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReservationTime",
                table: "Guests",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ReservationName",
                table: "Guests",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Reservation",
                table: "Guests",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationTime",
                table: "Guests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ReservationName",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<bool>(
                name: "Reservation",
                table: "Guests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
