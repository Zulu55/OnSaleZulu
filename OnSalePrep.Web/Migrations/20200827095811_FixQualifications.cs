using Microsoft.EntityFrameworkCore.Migrations;

namespace OnSalePrep.Web.Migrations
{
    public partial class FixQualifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Qualifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_UserId",
                table: "Qualifications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_AspNetUsers_UserId",
                table: "Qualifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_AspNetUsers_UserId",
                table: "Qualifications");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_UserId",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Qualifications");
        }
    }
}
