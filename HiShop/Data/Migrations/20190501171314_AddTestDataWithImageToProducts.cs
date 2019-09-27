using Microsoft.EntityFrameworkCore.Migrations;

namespace HiShop.Data.Migrations
{
    public partial class AddTestDataWithImageToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Delete old records
            migrationBuilder.Sql("DELETE FROM [Products]");

            //Insert New Records
            migrationBuilder.Sql(@"INSERT INTO[Products] ( [Title], [IsExists], [NumberInStock], [Specification], [Price], [ImagePath]) VALUES(N'محصول نمونه 1      ', 1, 442, N'توضیحات مربوط به محصول نمونه 1', 75100000, N'/UserUploads/Products/201905010810587438.jpg')
                INSERT INTO[Products] ( [Title], [IsExists], [NumberInStock], [Specification], [Price], [ImagePath]) VALUES(N'محصول نمونه 2', 1, 560, N'توضیحات مربوط به محصول نمونه 2', 49970000, N'/UserUploads/Products/201905010810592408.jpg')
                INSERT INTO[Products] ( [Title], [IsExists], [NumberInStock], [Specification], [Price], [ImagePath]) VALUES(N'محصول نمونه 3', 1, 807, N'توضیحات مربوط به محصول نمونه 3', 68790000, N'/UserUploads/Products/201905010810592459.jpg')
                INSERT INTO[Products] ( [Title], [IsExists], [NumberInStock], [Specification], [Price], [ImagePath]) VALUES(N'محصول نمونه 4', 0, 821, N'توضیحات مربوط به محصول نمونه 4', 24830000, N'/UserUploads/Products/201905010810592480.jpg')
                INSERT INTO[Products] ( [Title], [IsExists], [NumberInStock], [Specification], [Price], [ImagePath]) VALUES(N'محصول نمونه 5', 1, 222, N'توضیحات مربوط به محصول نمونه 5', 18870000, N'/UserUploads/Products/201905010810592504.jpg')
                INSERT INTO[Products] ( [Title], [IsExists], [NumberInStock], [Specification], [Price], [ImagePath]) VALUES(N'محصول نمونه 6', 0, 38, N'توضیحات مربوط به محصول نمونه 6', 25360000, N'/UserUploads/Products/201905010810592528.jpg')
                INSERT INTO[Products] ( [Title], [IsExists], [NumberInStock], [Specification], [Price], [ImagePath]) VALUES(N'محصول نمونه 7', 1, 298, N'توضیحات مربوط به محصول نمونه 7', 20770000, N'/UserUploads/Products/201905010810592555.jpg')
                INSERT INTO[Products] ( [Title], [IsExists], [NumberInStock], [Specification], [Price], [ImagePath]) VALUES(N'محصول نمونه 8', 1, 628, N'توضیحات مربوط به محصول نمونه 8', 10970000, N'/UserUploads/Products/201905010810592579.jpg')
                INSERT INTO[Products] ( [Title], [IsExists], [NumberInStock], [Specification], [Price], [ImagePath]) VALUES(N'محصول نمونه 9', 1, 530, N'توضیحات مربوط به محصول نمونه 9', 13440000, N'/UserUploads/Products/201905010810592602.jpg')
                INSERT INTO[Products] ( [Title], [IsExists], [NumberInStock], [Specification], [Price], [ImagePath]) VALUES(N'محصول نمونه 10', 0, 776, N'توضیحات مربوط به محصول نمونه 10', 47650000, N'/UserUploads/Products/201905031238557220.jpg')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Products]");

            migrationBuilder.Sql(@"
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 1', 1, 790, N'توضیحات مربوط به محصول نمونه 1', 6070000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 2', 1, 271, N'توضیحات مربوط به محصول نمونه 2', 4230000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 3', 1, 705, N'توضیحات مربوط به محصول نمونه 3', 7470000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 4', 1, 253, N'توضیحات مربوط به محصول نمونه 4', 5970000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 5', 0, 297, N'توضیحات مربوط به محصول نمونه 5', 8090000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 6', 0, 170, N'توضیحات مربوط به محصول نمونه 6', 4790000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 7', 1, 908, N'توضیحات مربوط به محصول نمونه 7', 1330000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 8', 1, 129, N'توضیحات مربوط به محصول نمونه 8', 4490000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 9', 1, 46, N'توضیحات مربوط به محصول نمونه 9', 1350000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 10', 1, 943, N'توضیحات مربوط به محصول نمونه 10', 1400000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 11', 0, 862, N'توضیحات مربوط به محصول نمونه 11', 8400000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 12', 1, 967, N'توضیحات مربوط به محصول نمونه 12', 5170000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 13', 1, 584, N'توضیحات مربوط به محصول نمونه 13', 3610000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 14', 1, 340, N'توضیحات مربوط به محصول نمونه 14', 2410000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 15', 1, 527, N'توضیحات مربوط به محصول نمونه 15', 1050000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 16', 0, 288, N'توضیحات مربوط به محصول نمونه 16', 2070000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 17', 1, 599, N'توضیحات مربوط به محصول نمونه 17', 3760000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 18', 1, 59, N'توضیحات مربوط به محصول نمونه 18', 3810000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 19', 1, 176, N'توضیحات مربوط به محصول نمونه 19', 1970000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 20', 1, 697, N'توضیحات مربوط به محصول نمونه 20', 6680000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 21', 0, 925, N'توضیحات مربوط به محصول نمونه 21', 6360000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 22', 1, 680, N'توضیحات مربوط به محصول نمونه 22', 4470000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 23', 1, 783, N'توضیحات مربوط به محصول نمونه 23', 7100000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 24', 1, 780, N'توضیحات مربوط به محصول نمونه 24', 3470000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 25', 1, 384, N'توضیحات مربوط به محصول نمونه 25', 2720000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 26', 1, 204, N'توضیحات مربوط به محصول نمونه 26', 2840000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 27', 1, 955, N'توضیحات مربوط به محصول نمونه 27', 4950000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 28', 1, 869, N'توضیحات مربوط به محصول نمونه 28', 2490000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 29', 1, 893, N'توضیحات مربوط به محصول نمونه 29', 4640000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 30', 1, 788, N'توضیحات مربوط به محصول نمونه 30', 4970000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 31', 1, 288, N'توضیحات مربوط به محصول نمونه 31', 6930000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 32', 1, 692, N'توضیحات مربوط به محصول نمونه 32', 3970000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 33', 1, 183, N'توضیحات مربوط به محصول نمونه 33', 2450000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 34', 1, 998, N'توضیحات مربوط به محصول نمونه 34', 5320000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 35', 1, 219, N'توضیحات مربوط به محصول نمونه 35', 5120000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 36', 1, 543, N'توضیحات مربوط به محصول نمونه 36', 1110000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 37', 1, 745, N'توضیحات مربوط به محصول نمونه 37', 3270000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 38', 1, 758, N'توضیحات مربوط به محصول نمونه 38', 2980000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 39', 1, 212, N'توضیحات مربوط به محصول نمونه 39', 7620000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 40', 1, 197, N'توضیحات مربوط به محصول نمونه 40', 4400000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 41', 0, 446, N'توضیحات مربوط به محصول نمونه 41', 8080000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 42', 1, 310, N'توضیحات مربوط به محصول نمونه 42', 4920000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 43', 1, 980, N'توضیحات مربوط به محصول نمونه 43', 3230000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 44', 1, 127, N'توضیحات مربوط به محصول نمونه 44', 4430000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 45', 1, 140, N'توضیحات مربوط به محصول نمونه 45', 1320000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 46', 0, 837, N'توضیحات مربوط به محصول نمونه 46', 2680000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 47', 1, 262, N'توضیحات مربوط به محصول نمونه 47', 6640000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 48', 1, 164, N'توضیحات مربوط به محصول نمونه 48', 4040000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 49', 0, 363, N'توضیحات مربوط به محصول نمونه 49', 4800000)
            INSERT INTO [Products] ([Title], [IsExists], [NumberInStock], [Specification], [Price]) VALUES (N'محصول نمونه 50', 1, 648, N'توضیحات مربوط به محصول نمونه 50', 7480000)
            ");
        }
    }
}
