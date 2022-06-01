using AutoMapper;
using WiproTeste.Data.Entities;
using WiproTeste.DTOs;

namespace WiproTeste.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClientesModel, ClientesDto>().ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();
            CreateMap<FilmesModel, FilmesDto>().ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();
            CreateMap<LocacoesModel, LocacoesDto>()
                .ForMember(
                dest => dest.ClienteNome,
                opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(
                dest => dest.FilmeTitulo,
                opt => opt.MapFrom(src => src.Filme.Titulo)).ReverseMap();
            CreateMap<ClienteRequestDto,ClientesModel>();
        }
    }
}
