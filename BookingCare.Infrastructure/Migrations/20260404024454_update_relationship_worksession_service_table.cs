using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_relationship_worksession_service_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSessionServices");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "WorkSessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessions_ServiceId",
                table: "WorkSessions",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSessions_Services_ServiceId",
                table: "WorkSessions",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSessions_Services_ServiceId",
                table: "WorkSessions");

            migrationBuilder.DropIndex(
                name: "IX_WorkSessions_ServiceId",
                table: "WorkSessions");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "WorkSessions");

            migrationBuilder.CreateTable(
                name: "WorkSessionServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSessionServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSessionServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkSessionServices_WorkSessions_WorkSessionId",
                        column: x => x.WorkSessionId,
                        principalTable: "WorkSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessionServices_ServiceId",
                table: "WorkSessionServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessionServices_WorkSessionId",
                table: "WorkSessionServices",
                column: "WorkSessionId");
        }
    }
}
