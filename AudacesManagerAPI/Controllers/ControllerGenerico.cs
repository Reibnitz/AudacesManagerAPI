using AudacesManagerAPI.Data;
using AudacesManagerAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AudacesManagerAPI.Controllers
{
    public class ControllerGenerico<T1, T2> : ControllerBase
        where T1 : Model
    {
        private ApiContext _context;
        private DbSet<T1> _database;
        private IMapper _mapper;

        public ControllerGenerico(ApiContext context, IMapper mapper, DbSet<T1> database)
        {
            _context = context;
            _mapper = mapper;
            _database = database;
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_database);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            T1? item = _database.FirstOrDefault(item => item.Id == id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Adicionar(T2 itemDto)
        {
            T1 item = _mapper.Map<T1>(itemDto);
            _database.Add(item);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Listar), new { Id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] T2 itemNovo)
        {
            T1? item = _database.FirstOrDefault(item => item.Id == id);
            if (item == null)
                return NotFound();

            _mapper.Map(itemNovo, item);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            T1? item = _database.FirstOrDefault(item => item.Id == id);
            if (item == null)
                return NotFound();

            _context.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
