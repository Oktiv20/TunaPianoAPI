using System.ComponentModel.DataAnnotations;

namespace TunaPianoAPI.Models
{
    public class Artist
    {
        [Required]
        public int ArtistId { get; set; }
        public string? ArtistName { get; set;}
        public int? ArtistAge { get; set; }
        public string? ArtistBio { get; set; }
    }
}
