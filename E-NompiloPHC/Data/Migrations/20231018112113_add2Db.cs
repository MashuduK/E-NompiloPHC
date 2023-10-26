using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_NompiloPHC.Data.Migrations
{
    public partial class add2Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Referrals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedReferral = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferralDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferralReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    CancelledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelledReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referrals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referrals_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referrals_AspNetUsers_DoctorId1",
                        column: x => x.DoctorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Referrals_AspNetUsers_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_AppointmentId",
                table: "Referrals",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_DoctorId1",
                table: "Referrals",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_PatientId1",
                table: "Referrals",
                column: "PatientId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Referrals");
        }
    }
}
