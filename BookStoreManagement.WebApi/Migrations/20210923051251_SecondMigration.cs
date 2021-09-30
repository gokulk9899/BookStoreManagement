using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreManagement.WebApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "OrdersTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrdersTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "OrdersTbl");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrdersTbl");
        }
    }
}
