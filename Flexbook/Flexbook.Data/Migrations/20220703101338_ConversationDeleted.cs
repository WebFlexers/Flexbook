using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Flexbook.Data.Migrations
{
    public partial class ConversationDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Conversations_ConversationId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ConversationId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "AuthorHostId",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorHostId",
                table: "Comments",
                column: "AuthorHostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Authors_AuthorHostId",
                table: "Comments",
                column: "AuthorHostId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Authors_AuthorHostId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AuthorHostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AuthorHostId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "Comments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ConversationId",
                table: "Comments",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_AuthorId",
                table: "Conversations",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Conversations_ConversationId",
                table: "Comments",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id");
        }
    }
}
