using Microsoft.EntityFrameworkCore.Migrations;

namespace HiShop.Data.Migrations
{
    public partial class AddTestDataToCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO [Categories] ([Title], [Description], [ImagePath]) VALUES (N'دسته بندی نمونه 1', N'توضیحات مربوط به دسته بندی نمونه 1', N'/UserUploads/Categories/201905081057363889.jpg')
            INSERT INTO [Categories] ([Title], [Description], [ImagePath]) VALUES (N'دسته بندی نمونه 2', N'توضیحات مربوط به دسته بندی نمونه 2', N'/UserUploads/Categories/201905081106397205.jpg')
            INSERT INTO [Categories] ([Title], [Description], [ImagePath]) VALUES (N'دسته بندی نمونه 3', N'توضیحات مربوط به دسته بندی نمونه 3', N'/UserUploads/Categories/201905081107032012.jpg')
            INSERT INTO [Categories] ([Title], [Description], [ImagePath]) VALUES (N'دسته بندی نمونه 4', N'توضیحات مربوط به دسته بندی نمونه 4', N'/UserUploads/Categories/201905081107180979.jpg')
            INSERT INTO [Categories] ([Title], [Description], [ImagePath]) VALUES (N'دسته بندی نمونه 5', N'توضیحات مربوط به دسته بندی نمونه 5', N'/UserUploads/Categories/201905091234249866.jpg')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Categories]");
        }
    }
}
