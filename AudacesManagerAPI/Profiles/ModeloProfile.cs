using AudacesManagerAPI.Dtos.Modelo;
using AudacesManagerAPI.Models;
using AutoMapper;

namespace AudacesManagerAPI.Profiles
{
    public class ModeloProfile : Profile
    {
        public ModeloProfile()
        {
            CreateMap<CreateModeloDto, Modelo>();
            CreateMap<Modelo, ReadModeloDto>();
        }
    }
}
