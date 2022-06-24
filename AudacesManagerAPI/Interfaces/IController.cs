using Microsoft.AspNetCore.Mvc;

namespace AudacesManagerAPI.Interfaces
{
    public interface IController<T>
    {
        [HttpGet]
        public IActionResult Listar();

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id);

        [HttpPost]
        public IActionResult Adicionar(T model);

        [HttpPut("{id}")]
        public IActionResult Editar(int id, T model);

        [HttpDelete]
        public IActionResult Remover(int id);
    }
}
