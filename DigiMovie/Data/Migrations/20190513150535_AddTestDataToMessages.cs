﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiMovie.Data.Migrations
{
    public partial class AddTestDataToMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 1', N'email1@gmail.com', N'موضوع 1', N'متن پیام 1', N'2019-05-12 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 2', N'email2@gmail.com', N'موضوع 2', N'متن پیام 2', N'2019-05-11 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 3', N'email3@gmail.com', N'موضوع 3', N'متن پیام 3', N'2019-05-10 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 4', N'email4@gmail.com', N'موضوع 4', N'متن پیام 4', N'2019-05-09 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 5', N'email5@gmail.com', N'موضوع 5', N'متن پیام 5', N'2019-05-08 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 6', N'email6@gmail.com', N'موضوع 6', N'متن پیام 6', N'2019-05-07 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 7', N'email7@gmail.com', N'موضوع 7', N'متن پیام 7', N'2019-05-06 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 8', N'email8@gmail.com', N'موضوع 8', N'متن پیام 8', N'2019-05-05 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 9', N'email9@gmail.com', N'موضوع 9', N'متن پیام 9', N'2019-05-04 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 10', N'email10@gmail.com', N'موضوع 10', N'متن پیام 10', N'2019-05-03 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 11', N'email11@gmail.com', N'موضوع 11', N'متن پیام 11', N'2019-05-02 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 12', N'email12@gmail.com', N'موضوع 12', N'متن پیام 12', N'2019-05-01 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 13', N'email13@gmail.com', N'موضوع 13', N'متن پیام 13', N'2019-04-30 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 14', N'email14@gmail.com', N'موضوع 14', N'متن پیام 14', N'2019-04-29 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 15', N'email15@gmail.com', N'موضوع 15', N'متن پیام 15', N'2019-04-28 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 16', N'email16@gmail.com', N'موضوع 16', N'متن پیام 16', N'2019-04-27 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 17', N'email17@gmail.com', N'موضوع 17', N'متن پیام 17', N'2019-04-26 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 18', N'email18@gmail.com', N'موضوع 18', N'متن پیام 18', N'2019-04-25 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 19', N'email19@gmail.com', N'موضوع 19', N'متن پیام 19', N'2019-04-24 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 20', N'email20@gmail.com', N'موضوع 20', N'متن پیام 20', N'2019-04-23 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 21', N'email21@gmail.com', N'موضوع 21', N'متن پیام 21', N'2019-04-22 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 22', N'email22@gmail.com', N'موضوع 22', N'متن پیام 22', N'2019-04-21 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 23', N'email23@gmail.com', N'موضوع 23', N'متن پیام 23', N'2019-04-20 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 24', N'email24@gmail.com', N'موضوع 24', N'متن پیام 24', N'2019-04-19 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 25', N'email25@gmail.com', N'موضوع 25', N'متن پیام 25', N'2019-04-18 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 26', N'email26@gmail.com', N'موضوع 26', N'متن پیام 26', N'2019-04-17 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 27', N'email27@gmail.com', N'موضوع 27', N'متن پیام 27', N'2019-04-16 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 28', N'email28@gmail.com', N'موضوع 28', N'متن پیام 28', N'2019-04-15 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 29', N'email29@gmail.com', N'موضوع 29', N'متن پیام 29', N'2019-04-14 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 30', N'email30@gmail.com', N'موضوع 30', N'متن پیام 30', N'2019-04-13 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 31', N'email31@gmail.com', N'موضوع 31', N'متن پیام 31', N'2019-04-12 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 32', N'email32@gmail.com', N'موضوع 32', N'متن پیام 32', N'2019-04-11 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 33', N'email33@gmail.com', N'موضوع 33', N'متن پیام 33', N'2019-04-10 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 34', N'email34@gmail.com', N'موضوع 34', N'متن پیام 34', N'2019-04-09 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 35', N'email35@gmail.com', N'موضوع 35', N'متن پیام 35', N'2019-04-08 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 36', N'email36@gmail.com', N'موضوع 36', N'متن پیام 36', N'2019-04-07 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 37', N'email37@gmail.com', N'موضوع 37', N'متن پیام 37', N'2019-04-06 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 38', N'email38@gmail.com', N'موضوع 38', N'متن پیام 38', N'2019-04-05 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 39', N'email39@gmail.com', N'موضوع 39', N'متن پیام 39', N'2019-04-04 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 40', N'email40@gmail.com', N'موضوع 40', N'متن پیام 40', N'2019-04-03 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 41', N'email41@gmail.com', N'موضوع 41', N'متن پیام 41', N'2019-04-02 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 42', N'email42@gmail.com', N'موضوع 42', N'متن پیام 42', N'2019-04-01 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 43', N'email43@gmail.com', N'موضوع 43', N'متن پیام 43', N'2019-03-31 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 44', N'email44@gmail.com', N'موضوع 44', N'متن پیام 44', N'2019-03-30 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 45', N'email45@gmail.com', N'موضوع 45', N'متن پیام 45', N'2019-03-29 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 46', N'email46@gmail.com', N'موضوع 46', N'متن پیام 46', N'2019-03-28 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 47', N'email47@gmail.com', N'موضوع 47', N'متن پیام 47', N'2019-03-27 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 48', N'email48@gmail.com', N'موضوع 48', N'متن پیام 48', N'2019-03-26 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 49', N'email49@gmail.com', N'موضوع 49', N'متن پیام 49', N'2019-03-25 19:22:56', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 50', N'email50@gmail.com', N'موضوع 50', N'متن پیام 50', N'2019-03-24 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 51', N'email51@gmail.com', N'موضوع 51', N'متن پیام 51', N'2019-03-23 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 52', N'email52@gmail.com', N'موضوع 52', N'متن پیام 52', N'2019-03-22 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 53', N'email53@gmail.com', N'موضوع 53', N'متن پیام 53', N'2019-03-21 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 54', N'email54@gmail.com', N'موضوع 54', N'متن پیام 54', N'2019-03-20 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 55', N'email55@gmail.com', N'موضوع 55', N'متن پیام 55', N'2019-03-19 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 56', N'email56@gmail.com', N'موضوع 56', N'متن پیام 56', N'2019-03-18 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 57', N'email57@gmail.com', N'موضوع 57', N'متن پیام 57', N'2019-03-17 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 58', N'email58@gmail.com', N'موضوع 58', N'متن پیام 58', N'2019-03-16 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 59', N'email59@gmail.com', N'موضوع 59', N'متن پیام 59', N'2019-03-15 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 60', N'email60@gmail.com', N'موضوع 60', N'متن پیام 60', N'2019-03-14 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 61', N'email61@gmail.com', N'موضوع 61', N'متن پیام 61', N'2019-03-13 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 62', N'email62@gmail.com', N'موضوع 62', N'متن پیام 62', N'2019-03-12 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 63', N'email63@gmail.com', N'موضوع 63', N'متن پیام 63', N'2019-03-11 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 64', N'email64@gmail.com', N'موضوع 64', N'متن پیام 64', N'2019-03-10 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 65', N'email65@gmail.com', N'موضوع 65', N'متن پیام 65', N'2019-03-09 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 66', N'email66@gmail.com', N'موضوع 66', N'متن پیام 66', N'2019-03-08 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 67', N'email67@gmail.com', N'موضوع 67', N'متن پیام 67', N'2019-03-07 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 68', N'email68@gmail.com', N'موضوع 68', N'متن پیام 68', N'2019-03-06 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 69', N'email69@gmail.com', N'موضوع 69', N'متن پیام 69', N'2019-03-05 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 70', N'email70@gmail.com', N'موضوع 70', N'متن پیام 70', N'2019-03-04 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 71', N'email71@gmail.com', N'موضوع 71', N'متن پیام 71', N'2019-03-03 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 72', N'email72@gmail.com', N'موضوع 72', N'متن پیام 72', N'2019-03-02 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 73', N'email73@gmail.com', N'موضوع 73', N'متن پیام 73', N'2019-03-01 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 74', N'email74@gmail.com', N'موضوع 74', N'متن پیام 74', N'2019-02-28 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 75', N'email75@gmail.com', N'موضوع 75', N'متن پیام 75', N'2019-02-27 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 76', N'email76@gmail.com', N'موضوع 76', N'متن پیام 76', N'2019-02-26 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 77', N'email77@gmail.com', N'موضوع 77', N'متن پیام 77', N'2019-02-25 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 78', N'email78@gmail.com', N'موضوع 78', N'متن پیام 78', N'2019-02-24 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 79', N'email79@gmail.com', N'موضوع 79', N'متن پیام 79', N'2019-02-23 19:22:57', 0, 0)
INSERT INTO [Messages] ([Name], [Email], [Subject], [Body], [RegisteredTime], [IsRead], [IsStarred]) VALUES ( N'پیام نمونه 80', N'email80@gmail.com', N'موضوع 80', N'متن پیام 80', N'2019-02-22 19:22:57', 0, 0)

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Messages]");
        }
    }
}
