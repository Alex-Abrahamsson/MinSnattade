using Inlamningsuppgift_Marie.Models.Album;
namespace Inlamningsuppgift_Marie.Models.Artist
{
    public class Artist
    {
        public int Id { get; set; }
        public string ArtistName { get; set; } = null!;
        public int AlbumQuantity { get; set; }

        public List<Album.Album> Albums { get; set; } = null!;
    }
}
