namespace Inlamningsuppgift_Marie.Models.Song
{
    public class ReadSongModel
    {
        public int SongId { get; set; }
        public string SongName { get; set; } = null!;
        public string SongLength { get; set; } = null!;
    }
}
