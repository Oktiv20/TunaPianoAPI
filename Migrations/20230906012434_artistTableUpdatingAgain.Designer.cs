﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPianoAPI.Migrations
{
    [DbContext(typeof(TunaPianoAPIDbContext))]
    [Migration("20230906012434_artistTableUpdatingAgain")]
    partial class artistTableUpdatingAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.Property<int>("GenresGenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SongsSongId")
                        .HasColumnType("integer");

                    b.HasKey("GenresGenreId", "SongsSongId");

                    b.HasIndex("SongsSongId");

                    b.ToTable("SongGenre", (string)null);
                });

            modelBuilder.Entity("TunaPianoAPI.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ArtistId"));

                    b.Property<int?>("ArtistAge")
                        .HasColumnType("integer");

                    b.Property<string>("ArtistBio")
                        .HasColumnType("text");

                    b.Property<string>("ArtistName")
                        .HasColumnType("text");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            ArtistAge = 45,
                            ArtistBio = "John Sturgill Simpson is an American country music singer-songwriter and actor. His album \"Metamodern Sounds in Country Music\" was nominated for a Grammy Award for Best Americana Album in 2014.",
                            ArtistName = "Sturgill Simpson"
                        },
                        new
                        {
                            ArtistId = 2,
                            ArtistAge = 36,
                            ArtistBio = "John Andrew Hull (born November 7, 1986), better known as Andy Hull, is an American singer, guitarist and songwriter for the indie rock band Manchester Orchestra.",
                            ArtistName = "Andy Hull"
                        });
                });

            modelBuilder.Entity("TunaPianoAPI.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GenreId"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("GenreDescription")
                        .HasColumnType("text");

                    b.HasKey("GenreId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            GenreDescription = "Country"
                        },
                        new
                        {
                            GenreId = 2,
                            GenreDescription = "Alternative"
                        },
                        new
                        {
                            GenreId = 3,
                            GenreDescription = "Indie-Rock"
                        });
                });

            modelBuilder.Entity("TunaPianoAPI.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SongId"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("SongAlbum")
                        .HasColumnType("text");

                    b.Property<string>("SongLength")
                        .HasColumnType("text");

                    b.Property<string>("SongTitle")
                        .HasColumnType("text");

                    b.HasKey("SongId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            SongId = 1,
                            ArtistId = 1,
                            SongAlbum = "Metamodern Sounds in Country Music",
                            SongLength = "4:02",
                            SongTitle = "Long White Line"
                        },
                        new
                        {
                            SongId = 2,
                            ArtistId = 2,
                            SongAlbum = "A Black Mile to the Surface",
                            SongLength = "6:59",
                            SongTitle = "The Silence"
                        });
                });

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.HasOne("TunaPianoAPI.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunaPianoAPI.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsSongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TunaPianoAPI.Models.Genre", b =>
                {
                    b.HasOne("TunaPianoAPI.Models.Artist", null)
                        .WithMany("Genres")
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("TunaPianoAPI.Models.Song", b =>
                {
                    b.HasOne("TunaPianoAPI.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TunaPianoAPI.Models.Artist", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
