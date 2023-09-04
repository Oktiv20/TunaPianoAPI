using System.ComponentModel.DataAnnotations;

namespace TunaPianoAPI.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string? GenreDescription { get; set; }
        public ICollection<Song>? Songs { get; set; }
    }
}
