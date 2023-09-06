using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TunaPianoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<TunaPianoAPIDbContext>(builder.Configuration["TunaPianoAPIDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// SONGS


app.MapGet("/tunapiano/songs", (TunaPianoAPIDbContext db) =>
{
    List<Song> songs = db.Songs.ToList();
    if (songs.Count == 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(songs);
});


app.MapGet("/tunapiano/songs/{songId}", (TunaPianoAPIDbContext db, int songId) =>
{
    Song song = db.Songs
    .Include(s => s.Genres)
    .Include(s => s.Artist)
    .FirstOrDefault(s => s.SongId == songId);
    if (song == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(song);
});


app.MapPost("/tunapiano/songs", (TunaPianoAPIDbContext db, Song song) =>
{
    try
    {
        db.Add(song);
        db.SaveChanges();
        return Results.Created($"/tunapiano/songs/{song.SongId}", song);
    }
    catch (DbUpdateException)
    {
        return Results.NotFound();
    }
});


app.MapPut("/tunapiano/songs/{songId}", (TunaPianoAPIDbContext db, int songId, Song song) =>
{
    Song updateSong = db.Songs.SingleOrDefault(s => s.SongId == songId);
    if (updateSong == null)
    {
        return Results.NotFound();
    }
    updateSong.SongTitle = song.SongTitle;
    updateSong.ArtistId = song.ArtistId;
    updateSong.SongAlbum = song.SongAlbum;
    updateSong.SongLength = song.SongLength;
    db.SaveChanges();
    return Results.Ok(updateSong);
});


app.MapDelete("/tunapiano/songs/{songId}", (TunaPianoAPIDbContext db, int songId) =>
{
    Song deleteSong = db.Songs.FirstOrDefault(s => s.SongId == songId);
    if (deleteSong == null)
    {
        return Results.NotFound();
    }
    db.Remove(deleteSong);
    db.SaveChanges();
    return Results.Ok(deleteSong);
});



// ARTISTS


app.MapGet("/tunapiano/artists", (TunaPianoAPIDbContext db) =>
{
    List<Artist> artists = db.Artists.ToList();
    if (artists.Count == 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(artists);
});


app.MapGet("/tunapiano/artists/{artistId}", (TunaPianoAPIDbContext db, int artistId) =>
{
    Artist artist = db.Artists
    .Include(a => a.Songs)
    .ThenInclude(a => a.Genres)
    .FirstOrDefault(a => a.ArtistId == artistId);
    if (artist == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(artist);
});


app.MapPost("/tunapiano/artists", (TunaPianoAPIDbContext db, Artist artist) =>
{
    try
    {
        db.Add(artist);
        db.SaveChanges();
        return Results.Created($"/tunapiano/artists/{artist.ArtistId}", artist);
    }
    catch (DbUpdateException)
    {
        return Results.NotFound();
    }
});


app.MapPut("/tunapiano/artists/{artistId}", (TunaPianoAPIDbContext db, int artistId, Artist artist) =>
{
    Artist updateArtist = db.Artists.SingleOrDefault(a => a.ArtistId == artistId);
    if (updateArtist == null)
    {
        return Results.NotFound();
    }
    updateArtist.ArtistName = artist.ArtistName;
    updateArtist.ArtistAge = artist.ArtistAge;
    updateArtist.ArtistBio = artist.ArtistBio;
    db.SaveChanges();
    return Results.Ok(updateArtist);
});


app.MapDelete("/tunapiano/artists/{artistId}", (TunaPianoAPIDbContext db, int artistId) =>
{
    Artist deleteArtist = db.Artists.FirstOrDefault(a => a.ArtistId == artistId);
    if (deleteArtist == null)
    {
        return Results.NotFound();
    }
    db.Remove(deleteArtist);
    db.SaveChanges();
    return Results.Ok(deleteArtist);
});


// GENRES


app.MapGet("/tunapiano/genres", (TunaPianoAPIDbContext db) =>
{
    List<Genre> genres = db.Genres.ToList();
    if (genres.Count == 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(genres);
});


app.MapGet("/tunapiano/genres/{genreId}", (TunaPianoAPIDbContext db, int genreId) =>
{
    Genre genre = db.Genres
    .Include(g => g.Songs)
    .FirstOrDefault(a => a.GenreId == genreId);
    if (genre == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(genre);
});


app.MapPost("/tunapiano/genres", (TunaPianoAPIDbContext db, Genre genre) =>
{
    try
    {
        db.Add(genre);
        db.SaveChanges();
        return Results.Created($"/tunapiano/genres/{genre.GenreId}", genre);
    }
    catch (DbUpdateException)
    {
        return Results.NotFound();
    }
});


app.MapPut("/tunapiano/genres/{genreId}", (TunaPianoAPIDbContext db, int genreId, Genre genre) =>
{
    Genre updateGenre = db.Genres.SingleOrDefault(g => g.GenreId == genreId);
    if (updateGenre == null)
    {
        return Results.NotFound();
    }
    updateGenre.GenreDescription = genre.GenreDescription;
    db.SaveChanges();
    return Results.Ok(updateGenre);
});


app.MapDelete("/tunapiano/genres/{genreId}", (TunaPianoAPIDbContext db, int genreId) =>
{
    Genre deleteGenre = db.Genres.FirstOrDefault(g => g.GenreId == genreId);
    if (deleteGenre == null)
    {
        return Results.NotFound();
    }
    db.Remove(deleteGenre);
    db.SaveChanges();
    return Results.Ok(deleteGenre);
});


app.Run();
