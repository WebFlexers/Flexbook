using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flexbook.Data.Migrations
{
    public partial class MultipleAddressNotPossibleAnymore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Addresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
