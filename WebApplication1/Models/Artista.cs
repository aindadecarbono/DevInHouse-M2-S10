using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Artista
    {
        public int Id { get; internal set; }
        [Required(ErrorMessage = "Nome do artista necessário")]
        public string Nome { get; set; }
        public string Pais { get; set; }
    }
}
