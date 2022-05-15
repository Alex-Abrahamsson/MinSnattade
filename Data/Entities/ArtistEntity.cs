using System.ComponentModel.DataAnnotations;

namespace Inlamningsuppgift_Marie.Data.Entities
{
    public class ArtistEntity
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        public string ArtistName { get; set; } = null!;

        public int AlbumQuantity
        {
            get
            {
                return Albums == null ? 0 : Albums.Count;
            }
        }
        public ICollection<AlbumEntity> Albums { get; set; } = null!;
    }
}
