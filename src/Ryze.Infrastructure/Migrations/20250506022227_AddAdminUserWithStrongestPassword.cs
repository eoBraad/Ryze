using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ryze.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUserWithStrongestPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "FirstLogin", "Gender", "IsActive", "Name", "Password", "Phone", "Role", "TeamId", "UpdatedAt" },
                values: new object[] { new Guid("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"), new DateTime(2005, 5, 6, 2, 22, 27, 360, DateTimeKind.Utc).AddTicks(6532), new DateTime(2025, 5, 6, 2, 22, 27, 360, DateTimeKind.Utc).AddTicks(6027), "admin@admin.com", false, 3, true, "ADMIN", "$2a$11$lpUoHmJRBr1K.32vhgDtIenVAN3V1wUG6RPItws1qi/2ohUMdTjdK", "(11) 99999-9999", "GlobalAdmin", null, new DateTime(2025, 5, 6, 2, 22, 27, 360, DateTimeKind.Utc).AddTicks(6258) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"));
        }
    }
}
