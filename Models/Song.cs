﻿using System.ComponentModel.DataAnnotations;

namespace TunaPianoAPI.Models
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        public string? SongTitle { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public string? SongAlbum { get; set; }
        public string? SongLength { get; set; }
        public ICollection<Genre>? Genres { get; set; }
    }
}
