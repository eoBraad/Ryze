using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ryze.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"),
                columns: new[] { "BirthDate", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2005, 5, 8, 16, 56, 38, 317, DateTimeKind.Utc).AddTicks(255), new DateTime(2025, 5, 8, 16, 56, 38, 316, DateTimeKind.Utc).AddTicks(9674), "$2a$11$.O/LJShyMhARjw3pc9kK2ePLKyMUYrkP/3i5bh50lv0Gdlw.npQsi", new DateTime(2025, 5, 8, 16, 56, 38, 316, DateTimeKind.Utc).AddTicks(9890) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"),
                columns: new[] { "BirthDate", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2005, 5, 6, 2, 22, 27, 360, DateTimeKind.Utc).AddTicks(6532), new DateTime(2025, 5, 6, 2, 22, 27, 360, DateTimeKind.Utc).AddTicks(6027), "$2a$11$lpUoHmJRBr1K.32vhgDtIenVAN3V1wUG6RPItws1qi/2ohUMdTjdK", new DateTime(2025, 5, 6, 2, 22, 27, 360, DateTimeKind.Utc).AddTicks(6258) });
        }
    }
}
