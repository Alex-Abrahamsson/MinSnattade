namespace Inlamningsuppgift_Marie.Models.Album
{
    public class CreateAlbumModel
    {
        public string AlbumName { get; set; } = null!;
        public int ArtistId { get; set; }
    }
}
