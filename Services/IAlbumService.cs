using AutoMapper;
using Inlamningsuppgift_Marie.Data;
using Inlamningsuppgift_Marie.Data.Entities;
using Inlamningsuppgift_Marie.Models.Album;
using Inlamningsuppgift_Marie.Models.Artist;
using Microsoft.EntityFrameworkCore;

namespace Inlamningsuppgift_Marie.Services
{
    public interface IAlbumService
    {
        public Task<NewAlbumModel> CreateAlbumAsync(CreateAlbumModel request);
        public Task<AlbumEntity> UpdateAlbumAsync(int id, Album request);

        public Task<Album> GetAlbumByIdAsync(int albumId);
        public Task<IEnumerable<Album>> GetAllAlbumsAsync();
        public Task<bool> DeleteAlbumAsync(int albumId);
    }








    public class AlbumService : IAlbumService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public AlbumService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<NewAlbumModel> CreateAlbumAsync(CreateAlbumModel request)
        {
            if (!await _databaseContext.Albums.AnyAsync(x => x.AlbumName == request.AlbumName))
            {
                var albumEntity = _mapper.Map<AlbumEntity>(request);
                //await _databaseContext.AddAsync(albumEntity);
                _databaseContext.Add(albumEntity);
                await _databaseContext.SaveChangesAsync();

                return _mapper.Map<NewAlbumModel>(albumEntity);
            }
            return null;
        }

        public async Task<bool> DeleteAlbumAsync(int albumId)
        {
            var albumEntity = await _databaseContext.Albums.FindAsync(albumId);
            if (albumEntity != null)
            {
                _databaseContext.Remove(albumEntity);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Album> GetAlbumByIdAsync(int albumId)
        {
            /* MED DENNA DEL FÅR JAG UT NAMN PÅ ARTISTEN OSV MEN DÅ FUNKAR INTE SONGQUANTITY OCH LISTAN PÅ SONGS
             * =============================================================================================
             * var albumEnitie = await _databaseContext.Albums.FindAsync(albumId);
            albumEnitie.Artist = await _databaseContext.Artists.FindAsync(albumEnitie.ArtistId);

            return _mapper.Map<Album>(albumEnitie);
            ================================================================================================*/

            // MED DENNA DEL FÅR JAG UT SÅ SOM DET SKA VARA MEN NULL PÅ ARTISTNAME OCH LENGTH
            var albumEntity = await _databaseContext.Albums.Include(x => x.Songs).FirstOrDefaultAsync(x => x.AlbumId == albumId);
            if (albumEntity != null)
            {
                return _mapper.Map<Album>(albumEntity);
            }
            return null!;

        }

        public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
        {
            return _mapper.Map<IEnumerable<Album>>(await _databaseContext.Albums.Include(x => x.Artist).ToListAsync());
        }



        public async Task<AlbumEntity> UpdateAlbumAsync(int id, Album request)
        {
            var albumEntity = await _databaseContext.Albums.FirstOrDefaultAsync(x => x.AlbumId == id);
            if (albumEntity != null)
            {
                _databaseContext.Entry(albumEntity).State = EntityState.Modified;
                await _databaseContext.SaveChangesAsync();
                return _mapper.Map<AlbumEntity>(albumEntity);
            }

            return null;
        }
    }
}
