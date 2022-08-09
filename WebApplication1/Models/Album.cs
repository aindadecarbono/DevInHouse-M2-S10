namespace WebApplication1.Models
{
    public class Album
    {
        public int Id { get; internal set; }
        public string Nome { get; set; }

        public string Genero { get; set; }
        public int AnoLancamento { get; set; }

        public Artista Artista { get; set; }

        public Album(string nome, string genero, int anoLancamento, Artista artista)
        {
            
            Nome = nome;
            Genero = genero;
            AnoLancamento = anoLancamento;
            Artista = artista;
        }
    }
}
