using Microsoft.EntityFrameworkCore.Migrations;

namespace HiShop.Data.Migrations
{
    public partial class AddDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Add Default Users
            migrationBuilder.Sql(@"
                INSERT INTO [AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [BirthDate], [FirstName], [IsMale], [LastName], [RegisteredDateTime], [ProfileImagePath]) VALUES (N'b1d79837-6996-428a-8d35-c19c7a455d50', N'admin@admin.ir', N'ADMIN@ADMIN.IR', N'admin@admin.ir', N'ADMIN@ADMIN.IR', 1, N'AQAAAAEAACcQAAAAENl4J78TLK7J4Qb/y+11zbkOuqxbJmvRI2TlyJjASkmBOfbQDFb7QXgViDyvTn2q9w==', N'IGBX3K36VNEAM55M2BSAQVWGVKVSII6W', N'6b556bb0-b2c9-4e23-94ea-7a1a614659e6', NULL, 0, 0, NULL, 1, 0, N'2019-03-21 00:00:00', N'مدیر', 1, N'ارشد', N'2019-09-18 22:45:37', N'/UserUploads/UsersProfile/default.png')
            ");


            //Add Default Roles
            migrationBuilder.Sql(@"
                INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0ad91b0d-f3d5-452b-9a85-2fe57e113820', N'مدیر پیام ها', N'مدیر پیام ها', N'db92e479-0cdc-4f06-acbd-8fa465e7e39a')
                INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'76eef725-d90c-45b5-af54-75f678c9f37d', N'مدیر دسته بندی ها', N'مدیر دسته بندی ها', N'590185ee-b1a6-4439-9173-f4c3d7743610')
                INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bed7b949-4518-41a7-808a-1017d1b677be', N'مدیر محصولات', N'مدیر محصولات', N'7f869d13-c9be-4790-aa5b-a0f0d087e7c2')
                INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd2e67f5f-156a-42a1-91ff-46ba0dec1822', N'مدیر عضویت', N'مدیر عضویت', N'efb1fb79-86d5-4110-92b7-9a5ff81c7578')
            ");

            //Assign Users To Roles
            migrationBuilder.Sql(@"
                INSERT INTO[AspNetUserRoles]
                        ([UserId], [RoleId]) VALUES(N'b1d79837-6996-428a-8d35-c19c7a455d50', N'0ad91b0d-f3d5-452b-9a85-2fe57e113820')
                INSERT INTO[AspNetUserRoles]
                        ([UserId], [RoleId]) VALUES(N'b1d79837-6996-428a-8d35-c19c7a455d50', N'76eef725-d90c-45b5-af54-75f678c9f37d')
                INSERT INTO[AspNetUserRoles]
                        ([UserId], [RoleId]) VALUES(N'b1d79837-6996-428a-8d35-c19c7a455d50', N'bed7b949-4518-41a7-808a-1017d1b677be')
                INSERT INTO[AspNetUserRoles]
                        ([UserId], [RoleId]) VALUES(N'b1d79837-6996-428a-8d35-c19c7a455d50', N'd2e67f5f-156a-42a1-91ff-46ba0dec1822')
            ");
        }

    protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM [AspNetUserRoles]");
            migrationBuilder.Sql(@"DELETE FROM [AspNetRoles]");
            migrationBuilder.Sql(@"DELETE FROM [AspNetUsers]");
        }
    }
}
