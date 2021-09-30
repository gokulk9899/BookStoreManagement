using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreManagement.WebApi.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersCartTbl_BooksTbl_BookId",
                table: "OrdersCartTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersCartTbl_OrdersTbl_OrderId",
                table: "OrdersCartTbl");

            migrationBuilder.DropIndex(
                name: "IX_OrdersCartTbl_BookId",
                table: "OrdersCartTbl");

            migrationBuilder.DropIndex(
                name: "IX_OrdersCartTbl_OrderId",
                table: "OrdersCartTbl");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrdersTbl",
                newName: "OrderId");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "OrdersTbl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "OrdersTbl",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookName",
                table: "OrdersTbl");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrdersTbl");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrdersTbl",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersCartTbl_BookId",
                table: "OrdersCartTbl",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersCartTbl_OrderId",
                table: "OrdersCartTbl",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersCartTbl_BooksTbl_BookId",
                table: "OrdersCartTbl",
                column: "BookId",
                principalTable: "BooksTbl",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersCartTbl_OrdersTbl_OrderId",
                table: "OrdersCartTbl",
                column: "OrderId",
                principalTable: "OrdersTbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
