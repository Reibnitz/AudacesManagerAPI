using AudacesManagerAPI.Data;
using AudacesManagerAPI.Interfaces;
using AudacesManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudacesManagerAPI.Controllers
{
    [ApiController]
    [Route("modelos")]
    public class ModeloController : ControllerBase, IController<Modelo>
    {
        private ApiContext _context;

        public ModeloController(ApiContext context)
        {
            _context = context;
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
        public IActionResult Adicionar(Modelo modelo)
        {
            _context.Modelos.Add(modelo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Listar), new { Id = modelo.Id }, modelo);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Modelo modeloNovo)
        {
            Modelo? modelo = _context.Modelos.FirstOrDefault(modelo => modelo.Id == id);
            if (modelo == null)
                return NotFound();

            modelo.Nome = modeloNovo.Nome;
            modelo.Responsavel = modeloNovo.Responsavel;
            modelo.Tipo = modeloNovo.Tipo;
            modelo.Colecao = modeloNovo.Colecao;
            modelo.Bordado = modeloNovo.Bordado;
            modelo.Estampa = modeloNovo.Estampa;

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
