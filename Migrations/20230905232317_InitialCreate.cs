using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPianoAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArtistName = table.Column<string>(type: "text", nullable: true),
                    ArtistAge = table.Column<int>(type: "integer", nullable: true),
                    ArtistBio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SongTitle = table.Column<string>(type: "text", nullable: true),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    SongAlbum = table.Column<string>(type: "text", nullable: true),
                    SongLength = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                });

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    GenresGenreId = table.Column<int>(type: "integer", nullable: false),
                    SongsSongId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.GenresGenreId, x.SongsSongId });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Songs_SongsSongId",
                        column: x => x.SongsSongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "ArtistAge", "ArtistBio", "ArtistName" },
                values: new object[,]
                {
                    { 1, 45, "John Sturgill Simpson is an American country music singer-songwriter and actor. His album \"Metamodern Sounds in Country Music\" was nominated for a Grammy Award for Best Americana Album in 2014.", "Sturgill Simpson" },
                    { 2, 36, "John Andrew Hull (born November 7, 1986), better known as Andy Hull, is an American singer, guitarist and songwriter for the indie rock band Manchester Orchestra.", "Andy Hull" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreDescription" },
                values: new object[,]
                {
                    { 1, "Country" },
                    { 2, "Alternative" },
                    { 3, "Indie-Rock" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "ArtistId", "SongAlbum", "SongLength", "SongTitle" },
                values: new object[,]
                {
                    { 1, 1, "Metamodern Sounds in Country Music", new TimeSpan(0, 0, 4, 2, 0), "Long White Line" },
                    { 2, 2, "A Black Mile to the Surface", new TimeSpan(0, 0, 6, 59, 0), "The Silence" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_SongsSongId",
                table: "GenreSong",
                column: "SongsSongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
