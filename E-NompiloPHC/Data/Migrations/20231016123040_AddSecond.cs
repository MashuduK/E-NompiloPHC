using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_NompiloPHC.Data.Migrations
{
    public partial class AddSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
