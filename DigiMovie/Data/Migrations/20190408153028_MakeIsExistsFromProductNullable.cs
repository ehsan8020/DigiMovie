using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiMovie.Data.Migrations
{
    public partial class MakeIsExistsFromProductNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsExists",
                table: "Products",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsExists",
                table: "Products",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
