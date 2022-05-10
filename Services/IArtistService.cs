using AutoMapper;
using Inlamningsuppgift_Marie.Data;
using Inlamningsuppgift_Marie.Data.Entities;
using Inlamningsuppgift_Marie.Models.Album;
using Inlamningsuppgift_Marie.Models.Artist;
using Microsoft.EntityFrameworkCore;

namespace Inlamningsuppgift_Marie.Services
{
    public interface IArtistService
    {
        public Task<Artist> CreateArtistAsync(CreateArtistModel request);
        public Task<IEnumerable<Artist>> GetAllArtistsAsync();
        public Task<Artist> GetArtistByIdAsync(int id);
    }






    public class ArtistService : IArtistService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;


        public ArtistService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        public async Task<Artist> CreateArtistAsync(CreateArtistModel request)
        {
                var artistEntity = _mapper.Map<ArtistEntity>(request);

                await _databaseContext.AddAsync(artistEntity);
                await _databaseContext.SaveChangesAsync();
                return _mapper.Map<Artist>(artistEntity);
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return _mapper.Map<IEnumerable<Artist>>(await _databaseContext.Artists.ToListAsync());
        }

        public async Task<Artist> GetArtistByIdAsync(int artisId)
        {
            // Include(x => x.ArtistId == id)
            var artistEntity = await _databaseContext.Artists.FindAsync(artisId);
            if (artistEntity != null)
            {
                artistEntity.ArtistId = artisId;
                // skall returnera en lista på albumName och albumId
                //artistEntity.ArtistId = artisId;
                //await _databaseContext.SaveChangesAsync();

                return _mapper.Map<Artist>(artistEntity);

            }

            return null!;
        }
    }
}
