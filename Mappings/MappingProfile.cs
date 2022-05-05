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
            CreateMap<CreateArtistModel, Artist>()
                .ForMember(x => x.ArtistName, opt => opt.MapFrom(x => x.Name))
                .ReverseMap();
            CreateMap<CreateArtistModel, ArtistEntity>()
            .ForMember(x => x.ArtistName, opt => opt.MapFrom(x => x.Name))
            .ReverseMap();
            CreateMap<CreateAlbumModel, Album>()
            .ForMember(x => x.AlbumName, opt => opt.MapFrom(x => x.AlbumName))
            .ReverseMap();
            CreateMap<CreateAlbumModel, AlbumEntity>()
            .ForMember(x => x.ArtistName, opt => opt.MapFrom(x => x.Name))
            .ReverseMap();
        }
    }
}
