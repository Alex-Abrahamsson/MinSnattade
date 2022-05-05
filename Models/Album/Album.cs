namespace Inlamningsuppgift_Marie.Models.Album
{
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; } = null!;
        public string ArtistName { get; set; } = null!;
        public int SongsQuantity { get; set; }
    }
}
