using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlexbookData.Migrations
{
    public partial class AllFieldsLowerCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "books",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "books",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Pages",
                table: "books",
                newName: "pages");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "books",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "books",
                newName: "isbn");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "books",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "books",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "books",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "books",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "authors",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "authors",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "authors",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "authors",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "authors",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "books",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "pages",
                table: "books",
                newName: "Pages");

            migrationBuilder.RenameColumn(
                name: "isbn",
                table: "books",
                newName: "ISBN");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "books",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "books",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "books",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "books",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "authors",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "authors",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "authors",
                newName: "Fullname");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "authors",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "authors",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "authors",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
