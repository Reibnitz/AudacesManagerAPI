using AudacesManagerAPI.Data;
using AudacesManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudacesManagerAPI.Controllers
{
    [ApiController]
    [Route("colecoes")]
    public class ColecaoController : ControllerBase
    {
        private ApiContext _context;

        public ColecaoController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Adicionar(Colecao colecao)
        {
            _context.Colecoes.Add(colecao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ListarColecoes), new { Id = colecao.Id }, colecao);
        }

        [HttpGet]
        public IActionResult ListarColecoes()
        {
            return Ok(_context.Colecoes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarColecaoPorId(int id)
        {
            Colecao colecao = _context.Colecoes.FirstOrDefault(colecao => colecao.Id == id);
            if (colecao == null)
                return NotFound();

            return Ok(colecao);
        }

        [HttpPut("{id}")]
        public IActionResult EditarColecao(int id, [FromBody]Colecao colecaoNova)
        {
            Colecao colecao = _context.Colecoes.FirstOrDefault(colecao => colecao.Id == id);
            if (colecao == null)
                return NotFound();

            colecao.Nome = colecaoNova.Nome;
            colecao.Responsavel = colecaoNova.Responsavel;
            colecao.Estacao = colecaoNova.Estacao;
            colecao.Marca = colecaoNova.Marca;
            colecao.Orcamento = colecaoNova.Orcamento;
            colecao.Ano = colecaoNova.Ano;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverColecao(int id)
        {
            Colecao colecao = _context.Colecoes.FirstOrDefault(colecao => colecao.Id == id);
            if (colecao == null)
                return NotFound();

            _context.Remove(colecao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
