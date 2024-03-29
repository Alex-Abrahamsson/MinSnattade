﻿using Inlamningsuppgift_Marie.Models.Song;

namespace Inlamningsuppgift_Marie.Models.Album
{
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; } = null!;
        public int ArtistId { get; set; }
        public string ArtistName { get; set; } = null!;
        public int SongQuantity { get; set; }

        public List<ReadSongModel> Songs { get; set; } = null!;
    }
}
