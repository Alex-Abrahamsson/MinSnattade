using AutoMapper;
using Inlamningsuppgift_Marie.Data;
using Inlamningsuppgift_Marie.Data.Entities;
using Inlamningsuppgift_Marie.Models.Song;
using Microsoft.EntityFrameworkCore;

namespace Inlamningsuppgift_Marie.Services
{
    public interface ISongService
    {
        public Task<NewSongModel> CreateSongAsync(CreateSongModel request);
        public Task<Song> GetSongByIdAsync(int songId);
        public Task<Song> UpdateSongAsync(int songId, CreateSongModel request);
        public Task<bool> DeleteSongByIdAsync(int songId);
    }




    public class SongService : ISongService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public SongService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<NewSongModel> CreateSongAsync(CreateSongModel request)
        {
            if (!await _databaseContext.Songs.AnyAsync(x => x.SongName == request.SongName))
            {
                if (await _databaseContext.Albums.FindAsync(request.AlbumId) is null) return null;

                var songEntity = _mapper.Map<SongEntity>(request);
                _databaseContext.Songs.Add(songEntity);
                await _databaseContext.SaveChangesAsync();

                return _mapper.Map<NewSongModel>(songEntity);
            }

            return null;
        }

        public async Task<Song> GetSongByIdAsync(int songId)
        {

            // ALBUM NAME, ARTIST ID SAKNAS = KANSKE ÄNDRA SONG TILL NÅGOT?
            var songEntity = await _databaseContext.Songs.Include(x => x.Album).ThenInclude(x => x.Artist).FirstOrDefaultAsync(x => x.SongId == songId);
            if (songEntity != null)
            {
                return _mapper.Map<Song>(songEntity);
            }
            return null!;
        }

        public async Task<bool> DeleteSongByIdAsync(int songId)
        {
            var songEntity = await _databaseContext.Songs.FindAsync(songId);
            if (songEntity != null)
            {
                _databaseContext.Remove(songEntity);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Song> UpdateSongAsync(int songId, CreateSongModel request)
        {
            var songEntity = await _databaseContext.Songs.Include(x => x.Album).ThenInclude(x => x.Artist).FirstOrDefaultAsync(x => x.SongId == songId);
            if (songEntity != null)
            {
                if(await _databaseContext.Albums.FindAsync(request.AlbumId) is null) return null;

                _mapper.Map(request, songEntity);
                _databaseContext.Entry(songEntity).State = EntityState.Modified;
                await _databaseContext.SaveChangesAsync();
                return _mapper.Map<Song>(songEntity);
            }

            return null;
        }
    }
}
