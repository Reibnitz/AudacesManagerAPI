using AudacesManagerAPI.Data;
using AudacesManagerAPI.Dtos.Colecao;
using AudacesManagerAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AudacesManagerAPI.Controllers
{
    [ApiController]
    [Route("colecoes")]
    public class ColecaoController : ControllerGenerico<Colecao, CreateColecaoDto>
    {
        public ColecaoController(ApiContext context, IMapper mapper) : base (context, mapper, context.Colecoes)
        {
        }
    }
}
