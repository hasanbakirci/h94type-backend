using AutoMapper;
using h94type.API.Dtos.Requests.GenreRequest;
using h94type.API.Dtos.Requests.TextRequest;
using h94type.API.Models;

namespace h94type.API.Dtos.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTextRequest, Text>();
            CreateMap<UpdateTextRequest, Text>();
            CreateMap<Text, TextViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName));

            CreateMap<CreateGenreRequest, Genre>();
            CreateMap<UpdateGenreRequest, Genre>();
            CreateMap<Genre, GenreViewModel>();
        }
    }
}