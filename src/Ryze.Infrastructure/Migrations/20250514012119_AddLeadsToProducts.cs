using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ryze.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLeadsToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Leads_LeadId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LeadId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "LeadProduct",
                columns: table => new
                {
                    LeadsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadProduct", x => new { x.LeadsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_LeadProduct_Leads_LeadsId",
                        column: x => x.LeadsId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"),
                columns: new[] { "BirthDate", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2005, 5, 14, 1, 21, 18, 496, DateTimeKind.Utc).AddTicks(8978), new DateTime(2025, 5, 14, 1, 21, 18, 496, DateTimeKind.Utc).AddTicks(8542), "$2a$11$NEv.WmQyNlPVGpMFoKuRceXEHYZrzVKyrqeAa9ufsaCGh2M70aoSi", new DateTime(2025, 5, 14, 1, 21, 18, 496, DateTimeKind.Utc).AddTicks(8718) });

            migrationBuilder.CreateIndex(
                name: "IX_LeadProduct_ProductsId",
                table: "LeadProduct",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeadProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "LeadId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3f9e4e2-1f34-4d2b-a79f-5c3281a21e9b"),
                columns: new[] { "BirthDate", "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2005, 5, 14, 1, 18, 14, 548, DateTimeKind.Utc).AddTicks(7088), new DateTime(2025, 5, 14, 1, 18, 14, 548, DateTimeKind.Utc).AddTicks(6637), "$2a$11$j2h9t2I5IV1I0o9sWnS6I.dRZeZTX/fghrAm603BVFT2rejAAUk7G", new DateTime(2025, 5, 14, 1, 18, 14, 548, DateTimeKind.Utc).AddTicks(6812) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_LeadId",
                table: "Products",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Leads_LeadId",
                table: "Products",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id");
        }
    }
}
