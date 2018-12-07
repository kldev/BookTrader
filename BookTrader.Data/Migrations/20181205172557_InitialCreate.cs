using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookTrader.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bt_trader",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 100, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    last_name = table.Column<string>(maxLength: 100, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    password = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bt_trader", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bt_book",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 100, nullable: false),
                    trader_id = table.Column<string>(maxLength: 100, nullable: false),
                    title = table.Column<string>(maxLength: 200, nullable: false),
                    author = table.Column<string>(maxLength: 200, nullable: false),
                    sold_count = table.Column<int>(nullable: false, defaultValue: 0),
                    price = table.Column<decimal>(nullable: false, defaultValue: 0.0m),
                    added = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bt_book", x => x.id);
                    table.ForeignKey(
                        name: "FK_bt_book_bt_trader_trader_id",
                        column: x => x.trader_id,
                        principalTable: "bt_trader",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bt_book_trader_id",
                table: "bt_book",
                column: "trader_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bt_book");

            migrationBuilder.DropTable(
                name: "bt_trader");
        }
    }
}
