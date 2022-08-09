using WebApplication1.Models;
namespace WebApplication1.Repositories
{
    public class AlbumRepository
    {
        private static int _indiceId = 1;
        private static List<Album> _album = new();
        public Album Criar(Album album)
        {
            album.Id = _indiceId;
            _indiceId++;
            _album.Add(album);
            return album;
        }

        public Album Atualizar(int id, Album album)
        {
            var albumLista = _album.FirstOrDefault(lista => lista.Id == id);

            if (albumLista == null) return null;

            albumLista.Nome = album.Nome;
            albumLista.Genero = album.Genero;
            albumLista.AnoLancamento = album.AnoLancamento;
            albumLista.Artista = album.Artista;

            return album;
        }

        public void Remover(int id, Album album)
        {
            var albumLista = _album.FirstOrDefault(lista => lista.Id == id);

            _album.Remove(albumLista);

        }

        public List<Album> ObterTodos()
        {
            return _album;
        }

        public Album ObterPorId(int albumId)
        {
            return _album.FirstOrDefault(lista => lista.Id == albumId);
        }
    }
}
