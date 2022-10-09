using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSTracker.Data.Migrations
{
    public partial class AddedMoreColumsToGameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameSize",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameSize",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Games");
        }
    }
}
