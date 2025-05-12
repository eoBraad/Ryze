using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ryze.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTableAndLeadOriginColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeadOrigin",
                table: "Leads",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    LeadId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"),
                columns: new[] { "BirthDate", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2005, 5, 12, 19, 27, 28, 395, DateTimeKind.Utc).AddTicks(330), new DateTime(2025, 5, 12, 19, 27, 28, 394, DateTimeKind.Utc).AddTicks(9756), "$2a$11$3yz4hD30Q.HxOpPYkTI2iObbk5lHBec5kYVsSXrCn4p98PVvKavQK", new DateTime(2025, 5, 12, 19, 27, 28, 394, DateTimeKind.Utc).AddTicks(9958) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_LeadId",
                table: "Products",
                column: "LeadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropColumn(
                name: "LeadOrigin",
                table: "Leads");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"),
                columns: new[] { "BirthDate", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2005, 5, 8, 16, 56, 38, 317, DateTimeKind.Utc).AddTicks(255), new DateTime(2025, 5, 8, 16, 56, 38, 316, DateTimeKind.Utc).AddTicks(9674), "$2a$11$.O/LJShyMhARjw3pc9kK2ePLKyMUYrkP/3i5bh50lv0Gdlw.npQsi", new DateTime(2025, 5, 8, 16, 56, 38, 316, DateTimeKind.Utc).AddTicks(9890) });
        }
    }
}
