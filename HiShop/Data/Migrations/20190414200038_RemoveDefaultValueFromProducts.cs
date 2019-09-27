using Microsoft.EntityFrameworkCore.Migrations;

namespace HiShop.Data.Migrations
{
    public partial class RemoveDefaultValueFromProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "NumberInStock",
                table: "Products",
                nullable: false,
                oldClrType: typeof(short),
                oldDefaultValue: (short)50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "NumberInStock",
                table: "Products",
                nullable: false,
                defaultValue: (short)50,
                oldClrType: typeof(short));
        }
    }
}
