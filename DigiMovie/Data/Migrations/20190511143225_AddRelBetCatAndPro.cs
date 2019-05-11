using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiMovie.Data.Migrations
{
    public partial class AddRelBetCatAndPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "Products",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatId",
                table: "Products",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CatId",
                table: "Products",
                column: "CatId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CatId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "Products");
        }
    }
}
