using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brewery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brewery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wholesaler",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesaler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BreweryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsObsolete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beer_Brewery_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Brewery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WholesalerId = table.Column<Guid>(nullable: false),
                    BeerId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockItem_Beer_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockItem_Wholesaler_WholesalerId",
                        column: x => x.WholesalerId,
                        principalTable: "Wholesaler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brewery",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d985e71e-7b84-48af-8b32-fd87148d9c71"), "William Brew" },
                    { new Guid("25c74345-961b-49ac-9d2f-ed94123b3cc8"), "Genesis Brew" },
                    { new Guid("5fafa7da-1759-424d-a78f-ef81fe6479f8"), "Supreme Brew" },
                    { new Guid("cdb9fe2e-cda2-4c91-9a1b-35da889a9bed"), "Baguette Brew" },
                    { new Guid("426b9381-8de1-4b49-a600-035a99617984"), "Zuzu Pils" }
                });

            migrationBuilder.InsertData(
                table: "Wholesaler",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("eb891f07-af99-4f36-a2d4-0065cd8a1989"), "Genesis Shop" },
                    { new Guid("7ec52a66-5ce1-41ea-804c-2912873131fe"), "Zuzu Shop" },
                    { new Guid("68e33f1d-fefa-40f6-a117-5e601bd8a354"), "Pizza Beer" }
                });

            migrationBuilder.InsertData(
                table: "Beer",
                columns: new[] { "Id", "BreweryId", "IsObsolete", "Name" },
                values: new object[,]
                {
                    { new Guid("5a816ebf-0265-4f20-80fd-cbaf938fad6b"), new Guid("d985e71e-7b84-48af-8b32-fd87148d9c71"), false, "Willy Blond" },
                    { new Guid("79a13c8e-cbac-480d-910a-87b809cd8605"), new Guid("25c74345-961b-49ac-9d2f-ed94123b3cc8"), false, "Genesis IPA" },
                    { new Guid("dfabc6de-6ca1-4ec0-a10a-d4afe86d8dd3"), new Guid("5fafa7da-1759-424d-a78f-ef81fe6479f8"), false, "Supreme Red" },
                    { new Guid("3919b3af-db1d-481b-9f4a-a75b241e46ab"), new Guid("cdb9fe2e-cda2-4c91-9a1b-35da889a9bed"), false, "Du vin" },
                    { new Guid("bcfb22cf-e6ee-4ee5-969e-1e1bdae09edf"), new Guid("cdb9fe2e-cda2-4c91-9a1b-35da889a9bed"), false, "Toujours du vin" },
                    { new Guid("a30a3e77-4d7e-4ef8-9200-d2609fad5d11"), new Guid("426b9381-8de1-4b49-a600-035a99617984"), false, "Cara" },
                    { new Guid("54e4edd5-be1d-43c8-ab7d-c7073077985f"), new Guid("426b9381-8de1-4b49-a600-035a99617984"), false, "Heineken" }
                });

            migrationBuilder.InsertData(
                table: "StockItem",
                columns: new[] { "Id", "BeerId", "Quantity", "UnitPrice", "WholesalerId" },
                values: new object[,]
                {
                    { new Guid("d41d3f72-09f6-47e4-a23c-83023748bc6d"), new Guid("5a816ebf-0265-4f20-80fd-cbaf938fad6b"), 2, 1.5f, new Guid("eb891f07-af99-4f36-a2d4-0065cd8a1989") },
                    { new Guid("9b35f3f2-cd7d-4c7b-ba71-f6d550943075"), new Guid("79a13c8e-cbac-480d-910a-87b809cd8605"), 3, 2.5f, new Guid("7ec52a66-5ce1-41ea-804c-2912873131fe") },
                    { new Guid("0a9cfaa4-5eb6-4f40-b866-915db026acd5"), new Guid("dfabc6de-6ca1-4ec0-a10a-d4afe86d8dd3"), 25, 1.6f, new Guid("eb891f07-af99-4f36-a2d4-0065cd8a1989") },
                    { new Guid("6ad2fe99-5e9d-4c65-af04-c64d444621b8"), new Guid("3919b3af-db1d-481b-9f4a-a75b241e46ab"), 4, 1.9f, new Guid("68e33f1d-fefa-40f6-a117-5e601bd8a354") },
                    { new Guid("5c522eb3-bfb7-4f90-b4de-798cb9f6ce80"), new Guid("bcfb22cf-e6ee-4ee5-969e-1e1bdae09edf"), 2, 3.2f, new Guid("eb891f07-af99-4f36-a2d4-0065cd8a1989") },
                    { new Guid("51c8674f-4d63-4fba-8e5c-a9c34357bf65"), new Guid("a30a3e77-4d7e-4ef8-9200-d2609fad5d11"), 6, 0.5f, new Guid("68e33f1d-fefa-40f6-a117-5e601bd8a354") },
                    { new Guid("96494845-60eb-493b-8972-aeda77583136"), new Guid("54e4edd5-be1d-43c8-ab7d-c7073077985f"), 1, 1.9f, new Guid("7ec52a66-5ce1-41ea-804c-2912873131fe") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beer_BreweryId",
                table: "Beer",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_BeerId",
                table: "StockItem",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_WholesalerId",
                table: "StockItem",
                column: "WholesalerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockItem");

            migrationBuilder.DropTable(
                name: "Beer");

            migrationBuilder.DropTable(
                name: "Wholesaler");

            migrationBuilder.DropTable(
                name: "Brewery");
        }
    }
}
