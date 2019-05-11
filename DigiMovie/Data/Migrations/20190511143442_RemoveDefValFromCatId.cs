using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiMovie.Data.Migrations
{
    public partial class RemoveDefValFromCatId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CatId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CatId",
                table: "Products",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int));
        }
    }
}
