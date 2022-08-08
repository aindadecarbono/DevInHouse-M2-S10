using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ArtistaRepository
    {
        private int _indiceId = 1;
        private static List<Artista> _artistas = new();
        public Artista Criar(Artista artista) 
        { 
            artista.Id = _indiceId;
            _indiceId++;
            _artistas.Add(artista);
            return artista;
        }

        public Artista Atualizar(int id, Artista artista)
        {
            var artistaLista = _artistas.FirstOrDefault(lista => lista.Id == id);
            
            if (artistaLista == null) return null;

            artistaLista.Nome = artista.Nome;
            artistaLista.Pais = artista.Pais;

            return artista;
        }

        public void Remover(int id, Artista artista)
        {
            var artistaLista = _artistas.FirstOrDefault(lista => lista.Id == id);

            _artistas.Remove(artistaLista);
                        
        }

        public List<Artista> ObterTodos(string filtro)
        {
            if (!string.IsNullOrEmpty(filtro))
            {
                return _artistas.Where(a => a.Nome.Contains(filtro)).ToList();
            }
            return _artistas;
        }
    }
}
