using WebApplication1.Models;
namespace WebApplication1.Repositories
{
    public class MusicaRepository
    {
        private static int _indiceId = 1;
        private static List<Musica> _musica = new();
        public Musica Criar(Musica musica)
        {
            musica.Id = _indiceId;
            _indiceId++;
            _musica.Add(musica);
            return musica;
        }

        public Musica Atualizar(int id, Musica musica)
        {
            var musicaLista = _musica.FirstOrDefault(lista => lista.Id == id);

            if (musicaLista == null) return null;

            musicaLista.Nome = musica.Nome;
            musicaLista.Duracao = musica.Duracao;
            musicaLista.Album = musica.Album;
            musicaLista.Artista = musica.Artista;

            return musica;
        }

        public void Remover(int id, Musica musica)
        {
            var musicaLista = _musica.FirstOrDefault(lista => lista.Id == id);

            _musica.Remove(musicaLista);

        }

        public List<Musica> ObterTodos()
        {
            
            return _musica;
        }

        public List<Musica> ObterPorAlbum(int idAlbum)
        {
            return _musica
                .Where(m => m.Album != null)
                .Where(m => m.Album.Id == idAlbum)
                .ToList();
        }

    }
}
