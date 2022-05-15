using System.ComponentModel.DataAnnotations;

namespace Inlamningsuppgift_Marie.Data.Entities
{
    public class SongEntity
    {
        [Key]
        public int SongId { get; set; }

        [Required]
        public string SongName { get; set; } = null!;

        [Required]
        public string SongLength { get; set; } = null!;

        [Required]
        public int AlbumId { get; set; }

        public virtual AlbumEntity Album { get; set; } = null!;
    }
}
