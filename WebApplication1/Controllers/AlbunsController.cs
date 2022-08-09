using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/albuns")]
    public class AlbunsController: ControllerBase
    {
        private readonly AlbumRepository _albumRepository;
        private readonly ArtistaRepository _artistRepository;
        private readonly MusicaRepository _musicaRepository;

        public AlbunsController (AlbumRepository albumRepository, ArtistaRepository artistaRepository, MusicaRepository musicaRepository)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistaRepository;
            _musicaRepository = musicaRepository;
        }

        [HttpGet]
        public ActionResult<Album> Get()
        {
            return Ok(_albumRepository.ObterTodos());
        }

        [HttpGet("{idAlbum}/musicas")]
        public ActionResult<Musica> GetMusicasPorIdAlbum([FromRoute] int idAlbum)
        {
            return Ok(_musicaRepository.ObterPorAlbum(idAlbum));
        }

        [HttpPost]
        public ActionResult<Album> Post([FromBody] AlbumDTO albumJson)
        {
            var artista = _artistRepository.ObterPorId(albumJson.ArtistaId);

            var album = new Album(albumJson.Nome, albumJson.Genero, albumJson.AnoLancamento, artista);

            _albumRepository.Criar(album);

            return Ok(album);
        }

        [HttpPut("{idAlbum}")]
        public ActionResult<Album> Put([FromBody] AlbumDTO albumJson, [FromRoute] int idAlbum)
        {
            var artista = _artistRepository.ObterPorId(albumJson.ArtistaId);

            

            var album = _albumRepository.Atualizar(idAlbum, 
                new Album(albumJson.Nome, albumJson.Genero, albumJson.AnoLancamento, artista)
                );

            

            return Ok(album);
        }

        [HttpDelete("{idAlbum}")]
        public ActionResult Delete ([FromBody] Album album, [FromRoute] int idAlbum)
        {
            _albumRepository.Remover(idAlbum, album);
            return NoContent();
        }


    }
}
