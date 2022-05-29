using AutoMapper;
using WiproTeste.Data.Entities;
using WiproTeste.Models;

namespace WiproTeste.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Clientes, ClientesModel>().ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();
            CreateMap<Filmes, FilmesModel>().ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();
            CreateMap<Locacoes, LocacoesModel>()
                .ForMember(
                dest => dest.ClienteNome,
                opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(
                dest => dest.FilmeTitulo,
                opt => opt.MapFrom(src => src.Filme.Titulo)).ReverseMap();
            CreateMap<ClienteRequestModel,Clientes>();
        }
    }
}
