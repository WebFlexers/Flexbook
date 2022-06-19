using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexbookData.Migrations
{
    public partial class AddressFKAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "addressId",
                table: "authors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_authors_addressId",
                table: "authors",
                column: "addressId");

            migrationBuilder.AddForeignKey(
                name: "FK_authors_address_addressId",
                table: "authors",
                column: "addressId",
                principalTable: "address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authors_address_addressId",
                table: "authors");

            migrationBuilder.DropIndex(
                name: "IX_authors_addressId",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "addressId",
                table: "authors");
        }
    }
}
