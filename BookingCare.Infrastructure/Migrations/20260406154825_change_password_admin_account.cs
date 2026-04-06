using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_password_admin_account : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-1111-1111-1111-111111111111"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECAU7CUYk/UpTJd7hNEWSES8GqiNL5WIHG0BzyW15HYZQiF2Bb7hmkveVjC5dMBB4A==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-1111-1111-1111-111111111111"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJbUqD1X8w4w+E9X4M+zH8Jm6OQ/lFkM6fU6g1w+M5wz1gJ==");
        }
    }
}
