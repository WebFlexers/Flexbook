using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexbookData.Migrations
{
    public partial class RemoveUserTableAddAuthorsCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_conversation_conversation_id",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_User_user_id",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_conversation_comment_initial_comment_id",
                table: "conversation");

            migrationBuilder.DropForeignKey(
                name: "FK_conversation_User_host_id",
                table: "conversation");

            migrationBuilder.DropForeignKey(
                name: "FK_order_User_customer_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_item_order_order_id",
                table: "order_item");

            migrationBuilder.DropForeignKey(
                name: "FK_order_item_product_product_id",
                table: "order_item");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_product_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_User_author_id",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_item",
                table: "order_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_conversation",
                table: "conversation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comment",
                table: "comment");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "order_item",
                newName: "order_items");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "conversation",
                newName: "conversations");

            migrationBuilder.RenameTable(
                name: "comment",
                newName: "comments");

            migrationBuilder.RenameIndex(
                name: "IX_product_product_id",
                table: "products",
                newName: "IX_products_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_author_id",
                table: "products",
                newName: "IX_products_author_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_item_product_id",
                table: "order_items",
                newName: "IX_order_items_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_item_order_id",
                table: "order_items",
                newName: "IX_order_items_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_customer_id",
                table: "orders",
                newName: "IX_orders_customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_conversation_initial_comment_id",
                table: "conversations",
                newName: "IX_conversations_initial_comment_id");

            migrationBuilder.RenameIndex(
                name: "IX_conversation_host_id",
                table: "conversations",
                newName: "IX_conversations_host_id");

            migrationBuilder.RenameIndex(
                name: "IX_comment_user_id",
                table: "comments",
                newName: "IX_comments_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_comment_conversation_id",
                table: "comments",
                newName: "IX_comments_conversation_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_items",
                table: "order_items",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_conversations",
                table: "conversations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_conversations_conversation_id",
                table: "comments",
                column: "conversation_id",
                principalTable: "conversations",
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
                name: "FK_conversations_comments_initial_comment_id",
                table: "conversations",
                column: "initial_comment_id",
                principalTable: "comments",
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
                name: "FK_order_items_orders_order_id",
                table: "order_items",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_products_product_id",
                table: "order_items",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_User_customer_id",
                table: "orders",
                column: "customer_id",
                principalTable: "User",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_conversations_conversation_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_User_user_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_conversations_comments_initial_comment_id",
                table: "conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_conversations_User_host_id",
                table: "conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_orders_order_id",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_products_product_id",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_User_customer_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_products_products_product_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_User_author_id",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_items",
                table: "order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_conversations",
                table: "conversations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "order_items",
                newName: "order_item");

            migrationBuilder.RenameTable(
                name: "conversations",
                newName: "conversation");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "comment");

            migrationBuilder.RenameIndex(
                name: "IX_products_product_id",
                table: "product",
                newName: "IX_product_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_products_author_id",
                table: "product",
                newName: "IX_product_author_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_customer_id",
                table: "order",
                newName: "IX_order_customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_items_product_id",
                table: "order_item",
                newName: "IX_order_item_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_items_order_id",
                table: "order_item",
                newName: "IX_order_item_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_conversations_initial_comment_id",
                table: "conversation",
                newName: "IX_conversation_initial_comment_id");

            migrationBuilder.RenameIndex(
                name: "IX_conversations_host_id",
                table: "conversation",
                newName: "IX_conversation_host_id");

            migrationBuilder.RenameIndex(
                name: "IX_comments_user_id",
                table: "comment",
                newName: "IX_comment_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_comments_conversation_id",
                table: "comment",
                newName: "IX_comment_conversation_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_item",
                table: "order_item",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_conversation",
                table: "conversation",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comment",
                table: "comment",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_conversation_conversation_id",
                table: "comment",
                column: "conversation_id",
                principalTable: "conversation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_User_user_id",
                table: "comment",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_conversation_comment_initial_comment_id",
                table: "conversation",
                column: "initial_comment_id",
                principalTable: "comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_conversation_User_host_id",
                table: "conversation",
                column: "host_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_User_customer_id",
                table: "order",
                column: "customer_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_item_order_order_id",
                table: "order_item",
                column: "order_id",
                principalTable: "order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_item_product_product_id",
                table: "order_item",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
