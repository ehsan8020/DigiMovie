using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiMovie.Data.Migrations
{
    public partial class AddWebsiteRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0ad91b0d-f3d5-452b-9a85-2fe57e113820', N'مدیر پیام ها', N'مدیر پیام ها', N'db92e479-0cdc-4f06-acbd-8fa465e7e39a')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'76eef725-d90c-45b5-af54-75f678c9f37d', N'مدیر دسته بندی ها', N'مدیر دسته بندی ها', N'590185ee-b1a6-4439-9173-f4c3d7743610')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bed7b949-4518-41a7-808a-1017d1b677be', N'مدیر محصولات', N'مدیر محصولات', N'7f869d13-c9be-4790-aa5b-a0f0d087e7c2')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'cd5f7ab5-5bd5-46c5-addf-be9a50283bbc', N'مدیر ارشد', N'مدیر ارشد', N'09f9f815-3aed-4008-9597-97bdd536ddce')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd2e67f5f-156a-42a1-91ff-46ba0dec1822', N'مدیر کاربران', N'مدیر کاربران', N'efb1fb79-86d5-4110-92b7-9a5ff81c7578')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ffe03794-1e23-4f52-85b6-05e98547d82e', N'مدیر نقش ها', N'مدیر نقش ها', N'ae64f583-6d0a-4d4c-9f56-6046e5abb548')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM [AspNetRoles]");
        }
    }
}
