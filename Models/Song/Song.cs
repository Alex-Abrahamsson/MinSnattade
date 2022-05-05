namespace Inlamningsuppgift_Marie.Models.Song
{
    public class Song
    {
        public int Id { get; set; }
        public string SongName { get; set; } = null!;
        public string Length { get; set; } = null!;
        public int AlbumId { get; set; }
        public string ArtistName { get; set; } = null!;
    }
}
