using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_NompiloPHC.Data.Migrations
{
    public partial class RegisterDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "AspNetUsers",
                newName: "DepartmentyId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_DepartmentyId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDoctor",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentyId",
                table: "AspNetUsers",
                column: "DepartmentyId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDoctor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DepartmentyId",
                table: "AspNetUsers",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_DepartmentyId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
