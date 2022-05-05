namespace Inlamningsuppgift_Marie.Models.Song
{
    public class CreateSongModel
    {
        public string SongName { get; set; } = null!;
        public string Length { get; set; } = null!;
        public int AlbumId { get; set; }
    }
}
