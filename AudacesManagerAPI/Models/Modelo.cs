﻿using System.ComponentModel.DataAnnotations;

namespace AudacesManagerAPI.Models
{
    public class Modelo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Tipo { get; set; }
        public int Colecao { get; set; }
        public bool Bordado { get; set; }
        public bool Estampa { get; set; }
    }
}