using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexbookData.Migrations
{
    public partial class TablesSeperated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_User_customer_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_product_id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_author_id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_author_id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_product_id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "genre",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "isbn",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "language",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "pages",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "publication_date",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "publisher",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "summary",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                    table.ForeignKey(
                        name: "FK_authors_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_customers_User_id",
                        column: x => x.id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    isbn = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    genre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    publisher = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    publication_date = table.Column<DateOnly>(type: "date", nullable: false),
                    pages = table.Column<int>(type: "integer", nullable: false),
                    language = table.Column<DateOnly>(type: "date", maxLength: 50, nullable: false),
                    summary = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    author_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                    table.ForeignKey(
                        name: "FK_books_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_Product_id",
                        column: x => x.id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_author_id",
                table: "books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_books_product_id",
                table: "books",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_customer_id",
                table: "orders",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_customer_id",
                table: "orders");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "author_id",
                table: "Product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "genre",
                table: "Product",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "isbn",
                table: "Product",
                type: "character varying(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "language",
                table: "Product",
                type: "date",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pages",
                table: "Product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "Product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "publication_date",
                table: "Product",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "publisher",
                table: "Product",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "summary",
                table: "Product",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_author_id",
                table: "Product",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_product_id",
                table: "Product",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_User_customer_id",
                table: "orders",
                column: "customer_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product_product_id",
                table: "Product",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_author_id",
                table: "Product",
                column: "author_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
