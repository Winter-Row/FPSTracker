using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSTracker.Data.Migrations
{
    public partial class UpdatedMatchesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matchs_Games_GameId",
                table: "Matchs");

            migrationBuilder.AlterColumn<int>(
                name: "TeamScore",
                table: "Matchs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ratio",
                table: "Matchs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Matchs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OpponentScore",
                table: "Matchs",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matchs_Games_GameId",
                table: "Matchs",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matchs_Games_GameId",
                table: "Matchs");

            migrationBuilder.DropColumn(
                name: "OpponentScore",
                table: "Matchs");

            migrationBuilder.AlterColumn<int>(
                name: "TeamScore",
                table: "Matchs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Ratio",
                table: "Matchs",
                type: "real",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Matchs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matchs_Games_GameId",
                table: "Matchs",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
