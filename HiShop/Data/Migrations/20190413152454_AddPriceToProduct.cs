using Microsoft.EntityFrameworkCore.Migrations;

namespace HiShop.Data.Migrations
{
    public partial class AddPriceToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "NumberInStock",
                table: "Products",
                nullable: false,
                defaultValue: (short)50,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AlterColumn<short>(
                name: "NumberInStock",
                table: "Products",
                nullable: false,
                oldClrType: typeof(short),
                oldDefaultValue: (short)50);
        }
    }
}
