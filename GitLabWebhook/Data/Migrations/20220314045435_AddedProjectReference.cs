using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitLabWebhook.Migrations
{
    public partial class AddedProjectReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "Projects",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ChatId",
                table: "Projects",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Chats_ChatId",
                table: "Projects",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Chats_ChatId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ChatId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Projects");
        }
    }
}
