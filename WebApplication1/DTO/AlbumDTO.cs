using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class AlbumDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        public string Genero { get; set; }
        public int AnoLancamento { get; set; }
        [Required(ErrorMessage = "O artista é obrigatório")]
        [Range(1, int.MaxValue)]
        public int ArtistaId { get; set; }
    }
}
