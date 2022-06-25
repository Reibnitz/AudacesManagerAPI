using AudacesManagerAPI.Dtos.Colecao;
using AudacesManagerAPI.Models;
using AutoMapper;

namespace AudacesManagerAPI.Profiles
{
    public class ColecaoProfile : Profile
    {
        public ColecaoProfile()
        {
            CreateMap<CreateColecaoDto, Colecao>();
            CreateMap<Colecao, ReadColecaoDto>();
        }
    }
}
