using AudacesManagerAPI.Data.Dtos;
using AudacesManagerAPI.Models;
using AutoMapper;

namespace AudacesManagerAPI.Profiles
{
    public class ModeloProfile : Profile
    {
        public ModeloProfile()
        {
            CreateMap<Modelo, ModeloDto>();
            CreateMap<ModeloDto, Modelo>();
        }
    }
}
