using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiMovie.Data.Migrations
{
    public partial class AddUserAndAssignToAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Add User
            migrationBuilder.Sql(@"INSERT INTO [AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [BirthDate], [FirstName], [IsMale], [LastName], [RegisteredDateTime], [ProfileImagePath]) VALUES (N'295933bc-fbd3-40a4-8dd1-6cb25b6bd385', N'admin@admin.ir', N'ADMIN@ADMIN.IR', N'admin@admin.ir', N'ADMIN@ADMIN.IR', 1, N'AQAAAAEAACcQAAAAEMzU1nWe+fWvKH6vc0oTw1WDx2ImzsWGyJadWcMy5sNqh6AcjRZgyPCt4hpNer4vLQ==', N'YCA7CKJ7YPRJVJSYZENJKAMLNARH4VZQ', N'dcc83467-efa0-4776-8998-8e88741f6169', NULL, 0, 0, NULL, 1, 0, N'2019-03-21 00:00:00', N'مدیر ', 1, N'ارشد', N'2019-09-17 22:05:34', N'/UserUploads/UsersProfile/default.png')");

            //Assign Created User To Admin Role
            migrationBuilder.Sql(@"INSERT INTO [AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'295933bc-fbd3-40a4-8dd1-6cb25b6bd385', N'cd5f7ab5-5bd5-46c5-addf-be9a50283bbc')
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM [AspNetUsers]");
            migrationBuilder.Sql(@"DELETE FROM [AspNetUserRoles]");
        }
    }
}
