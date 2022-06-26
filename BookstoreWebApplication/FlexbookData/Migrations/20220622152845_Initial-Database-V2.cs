using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlexbookData.Migrations
{
    public partial class InitialDatabaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authors_address_addressId",
                table: "authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_authors",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "category",
                table: "books");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "authors",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "product",
                newName: "starting_price");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "product",
                newName: "image_path");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "User",
                newName: "address_id");

            migrationBuilder.RenameIndex(
                name: "IX_authors_addressId",
                table: "User",
                newName: "IX_User_address_id");

            migrationBuilder.AlterColumn<int>(
                name: "pages",
                table: "product",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "isbn",
                table: "product",
                type: "character varying(13)",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "product",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "author_id",
                table: "product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "final_price",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "language",
                table: "product",
                type: "date",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "publication_date",
                table: "product",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "publisher",
                table: "product",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "summary",
                table: "product",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image_path",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ordered_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    payment_method = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    discount = table.Column<float>(type: "real", nullable: false),
                    total_price = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_User_customer_id",
                        column: x => x.customer_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    order_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_item_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_item_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    image_path = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    datetime_written = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    likes = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    conversation_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "conversation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    host_id = table.Column<int>(type: "integer", nullable: false),
                    initial_comment_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conversation", x => x.id);
                    table.ForeignKey(
                        name: "FK_conversation_comment_initial_comment_id",
                        column: x => x.initial_comment_id,
                        principalTable: "comment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_conversation_User_host_id",
                        column: x => x.host_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_author_id",
                table: "product",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_product_id",
                table: "product",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_conversation_id",
                table: "comment",
                column: "conversation_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_user_id",
                table: "comment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_host_id",
                table: "conversation",
                column: "host_id");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_initial_comment_id",
                table: "conversation",
                column: "initial_comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_id",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_order_id",
                table: "order_item",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_product_id",
                table: "order_item",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_product_id",
                table: "product",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_User_author_id",
                table: "product",
                column: "author_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_address_address_id",
                table: "User",
                column: "address_id",
                principalTable: "address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_conversation_conversation_id",
                table: "comment",
                column: "conversation_id",
                principalTable: "conversation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_product_product_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_User_author_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_address_address_id",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_conversation_conversation_id",
                table: "comment");

            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "conversation");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_author_id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_product_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "image_path",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "product");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "final_price",
                table: "product");

            migrationBuilder.DropColumn(
                name: "language",
                table: "product");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "publication_date",
                table: "product");

            migrationBuilder.DropColumn(
                name: "publisher",
                table: "product");

            migrationBuilder.DropColumn(
                name: "summary",
                table: "product");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "authors");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "books");

            migrationBuilder.RenameColumn(
                name: "address_id",
                table: "authors",
                newName: "addressId");

            migrationBuilder.RenameIndex(
                name: "IX_User_address_id",
                table: "authors",
                newName: "IX_authors_addressId");

            migrationBuilder.RenameColumn(
                name: "starting_price",
                table: "books",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "image_path",
                table: "books",
                newName: "image");

            migrationBuilder.AlterColumn<int>(
                name: "pages",
                table: "books",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isbn",
                table: "books",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(13)",
                oldMaxLength: 13,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "books",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "books",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_authors",
                table: "authors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_authors_address_addressId",
                table: "authors",
                column: "addressId",
                principalTable: "address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
