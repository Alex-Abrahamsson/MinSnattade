using AutoMapper;
using Inlamningsuppgift_Marie.Data.Entities;
using Inlamningsuppgift_Marie.Models.Album;
using Inlamningsuppgift_Marie.Models.Artist;

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

            // ALBUM
            CreateMap<CreateAlbumModel, AlbumEntity>()
            .ForMember(x => x.AlbumName, opt => opt.MapFrom(x => x.AlbumName))
            .ReverseMap();

            CreateMap<NewAlbumModel, AlbumEntity>()
            .ForMember(x => x.AlbumName, opt => opt.MapFrom(x => x.AlbumName))
            .ReverseMap();

            CreateMap<AlbumEntity, Album>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.AlbumId))
            .ForMember(x => x.ArtistName, opt => opt.MapFrom(x => x.Artist.ArtistName))
            .ReverseMap();
        }
    }
}
