using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_index_filed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChatSessions_UserId",
                table: "ChatSessions");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_ChatSessionId",
                table: "ChatMessages");

            migrationBuilder.CreateIndex(
                name: "IX_ChatSessions_UserId_CreatedDate",
                table: "ChatSessions",
                columns: new[] { "UserId", "CreatedDate" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatSessionId_CreatedDate",
                table: "ChatMessages",
                columns: new[] { "ChatSessionId", "CreatedDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChatSessions_UserId_CreatedDate",
                table: "ChatSessions");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_ChatSessionId_CreatedDate",
                table: "ChatMessages");

            migrationBuilder.CreateIndex(
                name: "IX_ChatSessions_UserId",
                table: "ChatSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatSessionId",
                table: "ChatMessages",
                column: "ChatSessionId");
        }
    }
}
