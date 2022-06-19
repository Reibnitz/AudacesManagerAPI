using AudacesManagerAPI.Data.Dtos;
using AudacesManagerAPI.Models;
using AutoMapper;

namespace AudacesManagerAPI.Profiles
{
    public class ColecaoProfile : Profile
    {
        public ColecaoProfile()
        {
            CreateMap<Colecao, ColecaoDto>();
            CreateMap<ColecaoDto, Colecao>();
        }
    }
}
