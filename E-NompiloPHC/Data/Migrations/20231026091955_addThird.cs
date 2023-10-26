using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_NompiloPHC.Data.Migrations
{
    public partial class addThird : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_AspNetUsers_PatientId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Laboratories_AspNetUsers_PatientId",
                table: "Laboratories");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TestPrices_Laboratories_laboratoryId",
                table: "TestPrices");

            migrationBuilder.DropIndex(
                name: "IX_PatientReports_DoctorId",
                table: "PatientReports");

            migrationBuilder.DropIndex(
                name: "IX_PatientReports_PatientId",
                table: "PatientReports");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PatientId",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Laboratories",
                table: "Laboratories");

            migrationBuilder.RenameTable(
                name: "Laboratories",
                newName: "Laboratory");

            migrationBuilder.RenameColumn(
                name: "laboratoryId",
                table: "TestPrices",
                newName: "LaboratoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TestPrices_laboratoryId",
                table: "TestPrices",
                newName: "IX_TestPrices_LaboratoryId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameIndex(
                name: "IX_Laboratories_PatientId",
                table: "Laboratory",
                newName: "IX_Laboratory_PatientId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "PatientReports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "PatientReports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorId1",
                table: "PatientReports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "PatientReports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laboratory",
                table: "Laboratory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_DoctorId1",
                table: "PatientReports",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_PatientId1",
                table: "PatientReports",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PatientId1",
                table: "Bills",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_AspNetUsers_PatientId1",
                table: "Bills",
                column: "PatientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laboratory_AspNetUsers_PatientId",
                table: "Laboratory",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId1",
                table: "PatientReports",
                column: "DoctorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId1",
                table: "PatientReports",
                column: "PatientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestPrices_Laboratory_LaboratoryId",
                table: "TestPrices",
                column: "LaboratoryId",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_AspNetUsers_PatientId1",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Laboratory_AspNetUsers_PatientId",
                table: "Laboratory");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId1",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId1",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TestPrices_Laboratory_LaboratoryId",
                table: "TestPrices");

            migrationBuilder.DropIndex(
                name: "IX_PatientReports_DoctorId1",
                table: "PatientReports");

            migrationBuilder.DropIndex(
                name: "IX_PatientReports_PatientId1",
                table: "PatientReports");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PatientId1",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Laboratory",
                table: "Laboratory");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Laboratory",
                newName: "Laboratories");

            migrationBuilder.RenameColumn(
                name: "LaboratoryId",
                table: "TestPrices",
                newName: "laboratoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TestPrices_LaboratoryId",
                table: "TestPrices",
                newName: "IX_TestPrices_laboratoryId");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Laboratory_PatientId",
                table: "Laboratories",
                newName: "IX_Laboratories_PatientId");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "PatientReports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "PatientReports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laboratories",
                table: "Laboratories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_DoctorId",
                table: "PatientReports",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_PatientId",
                table: "PatientReports",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PatientId",
                table: "Bills",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_AspNetUsers_PatientId",
                table: "Bills",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laboratories_AspNetUsers_PatientId",
                table: "Laboratories",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestPrices_Laboratories_laboratoryId",
                table: "TestPrices",
                column: "laboratoryId",
                principalTable: "Laboratories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
