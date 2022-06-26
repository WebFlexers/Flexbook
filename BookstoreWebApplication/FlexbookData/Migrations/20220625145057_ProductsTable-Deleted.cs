using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexbookData.Migrations
{
    public partial class ProductsTableDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_items_products_product_id",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_products_products_product_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_User_author_id",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_products_product_id",
                table: "Product",
                newName: "IX_Product_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_products_author_id",
                table: "Product",
                newName: "IX_Product_author_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_Product_product_id",
                table: "order_items",
                column: "product_id",
                principalTable: "Product",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_items_Product_product_id",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_product_id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_author_id",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_product_id",
                table: "products",
                newName: "IX_products_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_author_id",
                table: "products",
                newName: "IX_products_author_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_products_product_id",
                table: "order_items",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_products_product_id",
                table: "products",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_User_author_id",
                table: "products",
                column: "author_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
