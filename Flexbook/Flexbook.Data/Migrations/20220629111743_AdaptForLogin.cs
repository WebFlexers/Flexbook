using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flexbook.Data.Migrations
{
    public partial class AdaptForLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(char[]),
                oldType: "character(1)[]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char[]>(
                name: "Password",
                table: "Users",
                type: "character(1)[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
