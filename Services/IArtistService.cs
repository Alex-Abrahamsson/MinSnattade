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
        public Task<Artist> GetArtistByIdAsync(int artistId);
        public Task<bool> DeleteArtistByIdAsync(int artistId);

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
            /* if (!await _databaseContext.Albums.AnyAsync(x => x.AlbumName == request.AlbumName))
            {
                if (await _databaseContext.Artists.FindAsync(request.ArtistId) is null) return null;

                var albumEntity = _mapper.Map<AlbumEntity>(request);
                _databaseContext.Add(albumEntity);
                await _databaseContext.SaveChangesAsync();

                return _mapper.Map<NewAlbumModel>(albumEntity);
            }
            */
            if (!await _databaseContext.Artists.AnyAsync(x => x.ArtistName == request.Name))
            {
                //if (await _databaseContext.Artists.FindAsync(request.Name) is null) return null;

                var artistEntity = _mapper.Map<ArtistEntity>(request);

                await _databaseContext.AddAsync(artistEntity);
                await _databaseContext.SaveChangesAsync();
                return _mapper.Map<Artist>(artistEntity);
            }
            return null;

        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return _mapper.Map<IEnumerable<Artist>>(await _databaseContext.Artists.ToListAsync());
        }

        public async Task<Artist> GetArtistByIdAsync(int artistId)
        {
            var artistEntity = await _databaseContext.Artists.Include(x => x.Albums).FirstOrDefaultAsync(x=> x.ArtistId == artistId);
            if (artistEntity != null)
            {
                //artistEntity.ArtistId = artisId;
                // skall returnera en lista på albumName och albumId
                //artistEntity.ArtistId = artisId;
                //await _databaseContext.SaveChangesAsync();

                return _mapper.Map<Artist>(artistEntity);

            }

            return null!;
        }
        public async Task<bool> DeleteArtistByIdAsync(int artistId)
        {
            var artistEntity = await _databaseContext.Artists.FindAsync(artistId);
            if (artistEntity!= null)
            {
                _databaseContext.Remove(artistEntity);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
