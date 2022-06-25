using AudacesManagerAPI.Data;
using AudacesManagerAPI.Dtos.Modelo;
using AudacesManagerAPI.Interfaces;
using AudacesManagerAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AudacesManagerAPI.Controllers
{
    [ApiController]
    [Route("modelos")]
    public class ModeloController : ControllerBase, IController<CreateModeloDto>
    {
        private ApiContext _context;
        private IMapper _mapper;

        public ModeloController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.Modelos);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Modelo? modelo = _context.Modelos.FirstOrDefault(modelo => modelo.Id == id);
            if (modelo == null)
                return NotFound();

            return Ok(modelo);
        }

        [HttpPost]
        public IActionResult Adicionar(CreateModeloDto modeloDto)
        {
            Modelo modelo = _mapper.Map<Modelo>(modeloDto);

            _context.Modelos.Add(modelo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Listar), new { Id = modelo.Id }, modelo);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] CreateModeloDto modeloNovo)
        {
            Modelo? modelo = _context.Modelos.FirstOrDefault(modelo => modelo.Id == id);
            if (modelo == null)
                return NotFound();

            _mapper.Map(modeloNovo, modelo);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            Modelo? modelo = _context.Modelos.FirstOrDefault(modelo => modelo.Id == id);
            if (modelo == null)
                return NotFound();

            _context.Remove(modelo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
