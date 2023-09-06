using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace TunaPianoAPI.Models
{
    public class Artist
    {
        [Required]
        public int ArtistId { get; set; }
        public string? ArtistName { get; set;}
        public int? ArtistAge { get; set; }
        public string? ArtistBio { get; set; }
        public List<Song> Songs { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
