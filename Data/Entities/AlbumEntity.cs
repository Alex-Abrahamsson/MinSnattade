using System.ComponentModel.DataAnnotations;

namespace Inlamningsuppgift_Marie.Data.Entities
{
    public class AlbumEntity
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string AlbumName { get; set; } = null!;

        [Required]
        public int ArtistId { get; set; }

        public int SongQuantity 
        {
            get
            {
                return Songs == null ? 0 : Songs.Count;
            }
        }

        public virtual ArtistEntity Artist { get; set; } = null!;
        public ICollection<SongEntity> Songs { get; set; } = null!;
    }
}
