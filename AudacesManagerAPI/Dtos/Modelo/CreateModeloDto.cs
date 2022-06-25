namespace AudacesManagerAPI.Dtos.Modelo
{
    public class CreateModeloDto
    {
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Tipo { get; set; }
        public int Colecao { get; set; }
        public bool Bordado { get; set; }
        public bool Estampa { get; set; }
    }
}
