using Microsoft.EntityFrameworkCore.Migrations;

namespace HiShop.Data.Migrations
{
    public partial class ChangePropNameOfMessageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsStared",
                table: "Messages",
                newName: "IsStarred");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsStarred",
                table: "Messages",
                newName: "IsStared");
        }
    }
}
