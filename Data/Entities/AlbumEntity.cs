﻿using System.ComponentModel.DataAnnotations;

namespace Inlamningsuppgift_Marie.Data.Entities
{
    public class AlbumEntity
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string AlbumName { get; set; } = null!;

        [Required]
        public string ArtistName { get; set; } = null!;

        [Required]
        public int SongQuantity { get; set; }

        [Required]
        public int ArtistId { get; set; }

        // ett album kan ha en artist??
        public virtual ArtistEntity Artist { get; set; } = null!;
    }
}