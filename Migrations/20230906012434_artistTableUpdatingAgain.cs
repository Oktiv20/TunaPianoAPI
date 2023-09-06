using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPianoAPI.Migrations
{
    public partial class artistTableUpdatingAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Genres",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ArtistId",
                table: "Genres",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Artists_ArtistId",
                table: "Genres",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Artists_ArtistId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_ArtistId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Genres");
        }
    }
}
