using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiMovie.Data.Migrations
{
    public partial class AddIsExistsToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExists",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExists",
                table: "Products");
        }
    }
}
