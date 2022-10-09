using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSTracker.Data.Migrations
{
    public partial class ChangedGameAndUsernameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_UserName_UserNameId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserNameId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserNameId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "UserName",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserName_GameId",
                table: "UserName",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserName_Games_GameId",
                table: "UserName",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserName_Games_GameId",
                table: "UserName");

            migrationBuilder.DropIndex(
                name: "IX_UserName_GameId",
                table: "UserName");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "UserNameId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserNameId",
                table: "Games",
                column: "UserNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_UserName_UserNameId",
                table: "Games",
                column: "UserNameId",
                principalTable: "UserName",
                principalColumn: "UserNameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
