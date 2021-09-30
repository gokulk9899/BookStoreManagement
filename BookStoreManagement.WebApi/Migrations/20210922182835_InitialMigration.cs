using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreManagement.WebApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksTbl",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksTbl", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "UsersTbl",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTbl", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "OrdersTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersTbl_UsersTbl_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersTbl",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersCartTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersCartTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersCartTbl_BooksTbl_BookId",
                        column: x => x.BookId,
                        principalTable: "BooksTbl",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersCartTbl_OrdersTbl_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrdersTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersCartTbl_BookId",
                table: "OrdersCartTbl",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersCartTbl_OrderId",
                table: "OrdersCartTbl",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersTbl_UserId",
                table: "OrdersTbl",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersCartTbl");

            migrationBuilder.DropTable(
                name: "BooksTbl");

            migrationBuilder.DropTable(
                name: "OrdersTbl");

            migrationBuilder.DropTable(
                name: "UsersTbl");
        }
    }
}
