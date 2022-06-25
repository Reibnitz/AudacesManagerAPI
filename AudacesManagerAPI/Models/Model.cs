using System.ComponentModel.DataAnnotations;

namespace AudacesManagerAPI.Models
{
    public class Model
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
