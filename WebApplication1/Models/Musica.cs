namespace WebApplication1.Models
{
    public class Musica
    {
        public int Id { get; internal set; }
        public string Nome { get; set; }
        public TimeSpan Duracao { get; set; }
        public Album Album { get; set; }
        public Artista Artista { get; set; }
    }
}
