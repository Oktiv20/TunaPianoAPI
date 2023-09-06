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



app.Run();
