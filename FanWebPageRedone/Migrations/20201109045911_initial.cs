using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FanWebPageRedone.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    StoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryTitle = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    UserNameUserId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.StoryId);
                    table.ForeignKey(
                        name: "FK_Topic_User_UserNameUserId",
                        column: x => x.UserNameUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topic_UserNameUserId",
                table: "Topic",
                column: "UserNameUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
