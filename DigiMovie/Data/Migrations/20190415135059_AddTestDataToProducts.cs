using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiMovie.Data.Migrations
{
    public partial class AddTestDataToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Products] (  [Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES ( N'محصول نمونه 1', 1, 1, N'توضیحات مربوط به محصول نمونه 1', 1000)
            INSERT INTO[dbo].[Products](  [Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES(N'محصول نمونه 2', 1, 2, N'توضیحات مربوط به محصول نمونه 2', 2000)
            INSERT INTO[dbo].[Products]
             (  [Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES(N'محصول نمونه 3', 1, 3, N'توضیحات مربوط به محصول نمونه 3', 3000)
            INSERT INTO[dbo].[Products]
            (  [Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES(N'محصول نمونه 4', 0, 4, N'توضیحات مربوط به محصول نمونه 4', 4000)
            INSERT INTO[dbo].[Products] (  [Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES(N'محصول نمونه 5', 1, 5, N'توضیحات مربوط به محصول نمونه 5', 5000)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[Products]");
        }
    }
}
