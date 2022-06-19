using AudacesManagerAPI.Data;
using AudacesManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudacesManagerAPI.Controllers
{
    [ApiController]
    [Route("modelos")]
    public class ModeloController : ControllerBase
    {
        private ApiContext _context;

        public ModeloController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Adicionar(Modelo modelo)
        {

            _context.Modelos.Add(modelo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ListarModelos), new { Id = modelo.Id }, modelo);
        }

        [HttpGet]
        public IActionResult ListarModelos()
        {
            return Ok(_context.Modelos);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarModeloPorId(int id)
        {
            Modelo modelo = _context.Modelos.FirstOrDefault(modelo => modelo.Id == id);
            if (modelo == null)
                return NotFound();

            return Ok(modelo);
        }

        [HttpPut("{id}")]
        public IActionResult EditarModelo(int id, [FromBody] Modelo modeloNovo)
        {
            Modelo modelo = _context.Modelos.FirstOrDefault(modelo => modelo.Id == id);
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
        public IActionResult RemoverModelo(int id)
        {
            Modelo modelo = _context.Modelos.FirstOrDefault(modelo => modelo.Id == id);
            if (modelo == null)
                return NotFound();

            _context.Remove(modelo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
