using AutoMapper;
using Inlamningsuppgift_Marie.Data;
using Inlamningsuppgift_Marie.Data.Entities;
using Inlamningsuppgift_Marie.Models.Album;
using Microsoft.EntityFrameworkCore;

namespace Inlamningsuppgift_Marie.Services
{
    public interface IAlbumService
    {
        public Task<Album> CreateAlbumAsync(CreateAlbumModel request);
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


        //skapa ett album
        public async Task<Album> CreateAlbumAsync(CreateAlbumModel request)
        {
            if (!await _databaseContext.Albums.AnyAsync(x => x.AlbumName == request.AlbumName))
            {
                var albumEntity = _mapper.Map<AlbumEntity>(request);

                _databaseContext.Add(albumEntity);
                await _databaseContext.SaveChangesAsync();

                return _mapper.Map<Album>(request);
            }
            return null;
        }

        public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
        {
            var albums = new List<Album>();
            foreach (var item in await _databaseContext.Albums.ToListAsync())
                albums.Add(new Album
                {
                    Id = item.AlbumId,
                    AlbumName = item.AlbumName,
                    ArtistName = item.ArtistName,
                    SongQuantity = item.SongQuantity
                });

            return albums;
        }
    }
}
