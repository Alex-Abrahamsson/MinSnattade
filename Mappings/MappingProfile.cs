using AutoMapper;
using Inlamningsuppgift_Marie.Data.Entities;
using Inlamningsuppgift_Marie.Models.Album;
using Inlamningsuppgift_Marie.Models.Artist;
using Inlamningsuppgift_Marie.Models.Song;

namespace Inlamningsuppgift_Marie.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ARTIST
            CreateMap<CreateArtistModel, ArtistEntity>()
            .ForMember(x => x.ArtistName, opt => opt.MapFrom(x => x.Name))
            .ReverseMap();

            
            CreateMap<ArtistEntity, Artist>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.ArtistId))
            .ReverseMap();

            CreateMap<ArtistEntity, NewArtistModel>()
            .ReverseMap();


            // ALBUM
            CreateMap<CreateAlbumModel, AlbumEntity>()
            .ForMember(x => x.AlbumName, opt => opt.MapFrom(x => x.AlbumName))
            .ReverseMap();

            CreateMap<AlbumEntity, NewAlbumModel>()
            .ForMember(x => x.AlbumName, opt => opt.MapFrom(x => x.AlbumName))
            .ReverseMap();

            CreateMap<AlbumEntity, Album>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.AlbumId))
            .ForMember(x => x.ArtistName, opt => opt.MapFrom(x => x.Artist.ArtistName))
            .ReverseMap();

            // SONG
            CreateMap<CreateSongModel, SongEntity>()
            .ForMember(x => x.SongLength, opt => opt.MapFrom(x => x.Length))
            .ReverseMap();

            CreateMap<NewSongModel, SongEntity>()
            .ReverseMap();

            CreateMap<SongEntity, ReadSongModel>();

            CreateMap<SongEntity, Song>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.SongId))
                .ForMember(x => x.Length, opt => opt.MapFrom(x => x.SongLength))
                .ForMember(x => x.ArtistName, opt => opt.MapFrom(x => x.Album.Artist.ArtistName));

            /*
            CreateMap<Album, Song>()
            .ForMember(x => x.AlbumId, opt => opt.MapFrom(x => x.Id))
            .ReverseMap();*/
        }
    }
}
