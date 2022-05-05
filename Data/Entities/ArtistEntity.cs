using System.ComponentModel.DataAnnotations;

namespace Inlamningsuppgift_Marie.Data.Entities
{
    public class ArtistEntity
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        public string ArtistName { get; set; } = null!;

        [Required]
        public int AlbumQuatity { get; set; }
        public ICollection<AlbumEntity> Albums { get; set; } = null!;
    }
}
