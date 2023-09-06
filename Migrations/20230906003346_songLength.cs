using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPianoAPI.Migrations
{
    public partial class songLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SongLength",
                table: "Songs",
                type: "text",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1,
                column: "SongLength",
                value: "4:02");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2,
                column: "SongLength",
                value: "6:59");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "SongLength",
                table: "Songs",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1,
                column: "SongLength",
                value: new TimeSpan(0, 0, 4, 2, 0));

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2,
                column: "SongLength",
                value: new TimeSpan(0, 0, 6, 59, 0));
        }
    }
}
