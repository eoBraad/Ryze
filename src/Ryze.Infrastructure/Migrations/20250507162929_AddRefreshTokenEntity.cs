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
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"),
                columns: new[] { "BirthDate", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2005, 5, 7, 16, 29, 28, 636, DateTimeKind.Utc).AddTicks(247), new DateTime(2025, 5, 7, 16, 29, 28, 635, DateTimeKind.Utc).AddTicks(9465), "$2a$11$6sug4ujNHs3wffWrCYI6Wu1T4SwyyfWGoAK/7aZOVbma8KvqIni4a", new DateTime(2025, 5, 7, 16, 29, 28, 635, DateTimeKind.Utc).AddTicks(9665) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"),
                columns: new[] { "BirthDate", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2005, 5, 6, 2, 22, 27, 360, DateTimeKind.Utc).AddTicks(6532), new DateTime(2025, 5, 6, 2, 22, 27, 360, DateTimeKind.Utc).AddTicks(6027), "$2a$11$lpUoHmJRBr1K.32vhgDtIenVAN3V1wUG6RPItws1qi/2ohUMdTjdK", new DateTime(2025, 5, 6, 2, 22, 27, 360, DateTimeKind.Utc).AddTicks(6258) });
        }
    }
}
