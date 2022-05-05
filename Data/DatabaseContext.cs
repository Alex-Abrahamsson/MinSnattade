using Inlamningsuppgift_Marie.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inlamningsuppgift_Marie.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<ArtistEntity> Artists { get; set; } = null!;
        public virtual DbSet<AlbumEntity> Albums { get; set; } = null!;
    }
}
