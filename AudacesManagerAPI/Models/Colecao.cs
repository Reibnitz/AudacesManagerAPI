using System.ComponentModel.DataAnnotations;

namespace AudacesManagerAPI.Models
{
    public class Colecao
    {
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Estacao { get; set; }
        public string Marca { get; set; }
        public double Orcamento { get; set; }
        public int Ano { get; set; }
        [Key]
        [Required]
        public int Id { get; set; }
    }
}