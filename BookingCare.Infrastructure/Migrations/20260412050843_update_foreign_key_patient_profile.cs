using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_foreign_key_patient_profile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientProfiles_Patients_PatientId",
                table: "PatientProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "PatientProfiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientProfiles_Patients_PatientId",
                table: "PatientProfiles",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientProfiles_Patients_PatientId",
                table: "PatientProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "PatientProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientProfiles_Patients_PatientId",
                table: "PatientProfiles",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
