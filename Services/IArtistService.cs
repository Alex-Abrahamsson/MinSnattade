using AutoMapper;
using Inlamningsuppgift_Marie.Data;
using Inlamningsuppgift_Marie.Data.Entities;
using Inlamningsuppgift_Marie.Models.Artist;
using Microsoft.EntityFrameworkCore;

namespace Inlamningsuppgift_Marie.Services
{
    public interface IArtistService
    {
        // skapa en artist
        public Task<NewArtistModel> CreateArtistAsync(CreateArtistModel request);
        public Task<IEnumerable<Artist>> GetAllArtistsAsync();
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
        public async Task<NewArtistModel> CreateArtistAsync(CreateArtistModel request)
        {
            if (!await _databaseContext.Artists.AnyAsync(x => x.ArtistName == request.Name))
            {
                var artistEntity = _mapper.Map<ArtistEntity>(request);

                await _databaseContext.AddAsync(artistEntity);
                await _databaseContext.SaveChangesAsync();
                return _mapper.Map<NewArtistModel>(artistEntity);
            }

            return null;


        }

        // GÖR SÅ DEN HÄR FUNKAR MED AUTOMAPPER
        // ============================================================

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return _mapper.Map<IEnumerable<Artist>>(await _databaseContext.Artists.ToListAsync());



            // .Include(x => x.Albums)

            /* FUNKAR UTAN MAPPER
             * 
            var artists = new List<Artist>();
            foreach (var item in await _databaseContext.Artists.ToListAsync())
                artists.Add(new Artist
                {
                    Id = item.ArtistId,
                    ArtistName = item.ArtistName,
                    AlbumQuantity = item.AlbumQuatity
                });

            return artists;*/
        }
    }
}
