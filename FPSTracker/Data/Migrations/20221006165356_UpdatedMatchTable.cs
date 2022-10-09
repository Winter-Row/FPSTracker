using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSTracker.Data.Migrations
{
    public partial class UpdatedMatchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamScore",
                table: "Matchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserNameId",
                table: "Matchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_UserNameId",
                table: "Matchs",
                column: "UserNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matchs_UserName_UserNameId",
                table: "Matchs",
                column: "UserNameId",
                principalTable: "UserName",
                principalColumn: "UserNameId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matchs_UserName_UserNameId",
                table: "Matchs");

            migrationBuilder.DropIndex(
                name: "IX_Matchs_UserNameId",
                table: "Matchs");

            migrationBuilder.DropColumn(
                name: "TeamScore",
                table: "Matchs");

            migrationBuilder.DropColumn(
                name: "UserNameId",
                table: "Matchs");
        }
    }
}
