using Microsoft.EntityFrameworkCore.Migrations;

namespace OnSalePrep.Web.Migrations
{
    public partial class AddFieldIsActiveOnProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
