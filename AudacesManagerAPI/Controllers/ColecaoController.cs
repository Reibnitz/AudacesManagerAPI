using AudacesManagerAPI.Data;
using AudacesManagerAPI.Dtos.Colecao;
using AudacesManagerAPI.Interfaces;
using AudacesManagerAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AudacesManagerAPI.Controllers
{
    [ApiController]
    [Route("colecoes")]
    public class ColecaoController : ControllerBase, IController<CreateColecaoDto>
    {
        private ApiContext _context;
        private IMapper _mapper;

        public ColecaoController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.Colecoes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Colecao? colecao = _context.Colecoes.FirstOrDefault(colecao => colecao.Id == id);
            if (colecao == null)
                return NotFound();

            return Ok(colecao);
        }

        [HttpPost]
        public IActionResult Adicionar(CreateColecaoDto colecaoDto)
        {
            Colecao colecao = _mapper.Map<Colecao>(colecaoDto);
            _context.Colecoes.Add(colecao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Listar), new { Id = colecao.Id }, colecao);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] CreateColecaoDto colecaoNova)
        {
            Colecao? colecao = _context.Colecoes.FirstOrDefault(colecao => colecao.Id == id);
            if (colecao == null)
                return NotFound();

            _mapper.Map(colecaoNova, colecao);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            Colecao? colecao = _context.Colecoes.FirstOrDefault(colecao => colecao.Id == id);
            if (colecao == null)
                return NotFound();

            _context.Remove(colecao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
