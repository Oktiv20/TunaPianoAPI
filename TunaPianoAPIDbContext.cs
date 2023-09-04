﻿using Microsoft.EntityFrameworkCore;
using TunaPianoAPI.Models;
using System.Runtime.CompilerServices;

public class TunaPianoAPIDbContext : DbContext
{

    public DbSet<Artist>? Artists { get; set; }
    public DbSet<Genre>? Genres { get; set; }
    public DbSet<Song>? Songs { get; set; }

    public TunaPianoAPIDbContext(DbContextOptions<TunaPianoAPIDbContext> context) : base(context) { }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Artist>().HasData(new Artist[]
        {
            new Artist { ArtistId = 1, ArtistName = "Sturgill Simpson", ArtistAge = 45, ArtistBio = "John Sturgill Simpson is an American country music singer-songwriter and actor. " +
            "His album \"Metamodern Sounds in Country Music\" was nominated for a Grammy Award for Best Americana Album in 2014." },

            new Artist { ArtistId = 2, ArtistName = "Andy Hull", ArtistAge = 36, ArtistBio = "John Andrew Hull (born November 7, 1986), better known as Andy Hull, " +
            "is an American singer, guitarist and songwriter for the indie rock band Manchester Orchestra." }
        });

        modelBuilder.Entity<Song>().HasData(new Song[]
        {
            new Song { SongId = 1, SongTitle = "The Silence", ArtistId = 2, SongAlbum = "A Black Mile to the Surface", SongLength = new TimeSpan(0, 6, 59) },
        })
    }
}