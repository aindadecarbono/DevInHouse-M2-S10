namespace WebApplication1.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Genero { get; set; }
        public int AnoLancamento { get; set; }

        public Artista Artista { get; set; }
    }
}
