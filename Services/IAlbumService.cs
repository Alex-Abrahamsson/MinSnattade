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

        public Task<Album> GetAlbumByIdAsync(int albumId);
        public Task<Album> UpdateAlbumAsync(int albumId, CreateAlbumModel request);
        public Task<bool> DeleteAlbumAsync(int albumId);
        public Task<IEnumerable<Album>> GetAllAlbumsAsync();

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
                if (await _databaseContext.Artists.FindAsync(request.ArtistId) is null) return null;

                var albumEntity = _mapper.Map<AlbumEntity>(request);
                _databaseContext.Add(albumEntity);
                await _databaseContext.SaveChangesAsync();

                return _mapper.Map<NewAlbumModel>(albumEntity);
            }
            return null;
        }

        public async Task<Album> GetAlbumByIdAsync(int albumId)
        {
            var albumEntity = await _databaseContext.Albums.Include(x => x.Songs).Include(x => x.Artist).FirstOrDefaultAsync(x => x.AlbumId == albumId);
            if (albumEntity != null)
            {
                return _mapper.Map<Album>(albumEntity);
            }
            return null!;

        }
        public async Task<Album> UpdateAlbumAsync(int albumId, CreateAlbumModel request)
        {
            var albumEntity = await _databaseContext.Albums.Include(x => x.Songs).Include(x => x.Artist).FirstOrDefaultAsync(x => x.AlbumId == albumId);
            if (albumEntity != null)
            {
                if (await _databaseContext.Artists.FindAsync(request.ArtistId) is null) return null;

                _mapper.Map(request, albumEntity);
                _databaseContext.Entry(albumEntity).State = EntityState.Modified;
                await _databaseContext.SaveChangesAsync();
                return _mapper.Map<Album>(albumEntity);
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

        public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
        {
            return _mapper.Map<IEnumerable<Album>>(await _databaseContext.Albums.Include(x => x.Artist).ToListAsync());
        }




    }
}
