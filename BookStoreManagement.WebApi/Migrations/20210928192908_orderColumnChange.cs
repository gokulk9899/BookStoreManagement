using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreManagement.WebApi.Migrations
{
    public partial class orderColumnChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookName",
                table: "OrdersTbl",
                newName: "BookTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookTitle",
                table: "OrdersTbl",
                newName: "BookName");
        }
    }
}
