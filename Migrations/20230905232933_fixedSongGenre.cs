using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPianoAPI.Migrations
{
    public partial class fixedSongGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreSong_Genres_GenresGenreId",
                table: "GenreSong");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreSong_Songs_SongsSongId",
                table: "GenreSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreSong",
                table: "GenreSong");

            migrationBuilder.RenameTable(
                name: "GenreSong",
                newName: "SongGenre");

            migrationBuilder.RenameIndex(
                name: "IX_GenreSong_SongsSongId",
                table: "SongGenre",
                newName: "IX_SongGenre_SongsSongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongGenre",
                table: "SongGenre",
                columns: new[] { "GenresGenreId", "SongsSongId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenre_Genres_GenresGenreId",
                table: "SongGenre",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenre_Songs_SongsSongId",
                table: "SongGenre",
                column: "SongsSongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongGenre_Genres_GenresGenreId",
                table: "SongGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenre_Songs_SongsSongId",
                table: "SongGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongGenre",
                table: "SongGenre");

            migrationBuilder.RenameTable(
                name: "SongGenre",
                newName: "GenreSong");

            migrationBuilder.RenameIndex(
                name: "IX_SongGenre_SongsSongId",
                table: "GenreSong",
                newName: "IX_GenreSong_SongsSongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreSong",
                table: "GenreSong",
                columns: new[] { "GenresGenreId", "SongsSongId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GenreSong_Genres_GenresGenreId",
                table: "GenreSong",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreSong_Songs_SongsSongId",
                table: "GenreSong",
                column: "SongsSongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
