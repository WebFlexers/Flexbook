using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexbookData.Migrations
{
    public partial class UserIdFromTextToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE authors ALTER COLUMN id TYPE INTEGER USING id::integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
