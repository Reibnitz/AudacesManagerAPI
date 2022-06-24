namespace AudacesManagerAPI.Dtos.Colecao
{
    public class CreateColecaoDto
    {
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Estacao { get; set; }
        public string Marca { get; set; }
        public double Orcamento { get; set; }
        public int Ano { get; set; }
    }
}
