using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlexbookData.Migrations
{
    public partial class UserTableTryToFix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authors_User_id",
                table: "authors");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_User_user_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_conversations_User_host_id",
                table: "conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_customers_User_id",
                table: "customers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_conversations_host_id",
                table: "conversations");

            migrationBuilder.DropIndex(
                name: "IX_comments_user_id",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "host_id",
                table: "conversations");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "comments");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "customers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "birthdate",
                table: "customers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "customers",
                type: "character varying(254)",
                maxLength: 254,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "fullname",
                table: "customers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image_path",
                table: "customers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phone_num",
                table: "customers",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "customers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "authors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "authors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "birthdate",
                table: "authors",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "authors",
                type: "character varying(254)",
                maxLength: 254,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "fullname",
                table: "authors",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image_path",
                table: "authors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "authors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phone_num",
                table: "authors",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "authors",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_customers_address_id",
                table: "customers",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_authors_address_id",
                table: "authors",
                column: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_authors_address_address_id",
                table: "authors",
                column: "address_id",
                principalTable: "address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customers_address_address_id",
                table: "customers",
                column: "address_id",
                principalTable: "address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authors_address_address_id",
                table: "authors");

            migrationBuilder.DropForeignKey(
                name: "FK_customers_address_address_id",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_address_id",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_authors_address_id",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "birthdate",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "email",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "fullname",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "image_path",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "password",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "phone_num",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "username",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "birthdate",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "email",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "fullname",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "image_path",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "password",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "phone_num",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "username",
                table: "authors");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "customers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "host_id",
                table: "conversations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "authors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address_id = table.Column<int>(type: "integer", nullable: false),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    fullname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    image_path = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    phone_num = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_conversations_host_id",
                table: "conversations",
                column: "host_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_id",
                table: "comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_address_id",
                table: "User",
                column: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_authors_User_id",
                table: "authors",
                column: "id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_User_user_id",
                table: "comments",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_conversations_User_host_id",
                table: "conversations",
                column: "host_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customers_User_id",
                table: "customers",
                column: "id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
