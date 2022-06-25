using AudacesManagerAPI.Data;
using AudacesManagerAPI.Dtos.Modelo;
using AudacesManagerAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AudacesManagerAPI.Controllers
{
    [ApiController]
    [Route("modelos")]
    public class ModeloController : ControllerGenerico<Modelo, CreateModeloDto>
    {
        public ModeloController(ApiContext context, IMapper mapper) : base(context, mapper, context.Modelos)
        {
        }
    }
}
