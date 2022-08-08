using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/artistas")]
    public class ArtistasController : ControllerBase
    {
        private readonly ArtistaRepository _artistaRepository;

        public ArtistasController(ArtistaRepository artistaRepository) 
        {
            _artistaRepository = artistaRepository;
        }
        
        [HttpGet]
        public ActionResult<Artista> Get([FromQuery] string filtro)
        {

            return Ok(_artistaRepository.ObterTodos(filtro));
        }

        [HttpPost]
        public ActionResult<Artista> Post([FromBody] Artista novoArtista)
        {
            var artista = _artistaRepository.Criar(novoArtista);

            return Ok(artista);
        }

        [HttpPut("{idArtista}")]
        public ActionResult<Artista> Put([FromBody] Artista artista, [FromRoute] int idArtista) 
        {
            var artistaEditado = _artistaRepository.Atualizar(idArtista, artista);
            return Ok(artistaEditado);
        }

        [HttpDelete("{idArtista}")]
        public ActionResult Remover([FromBody] Artista artista, [FromRoute] int idArtista)
        {
            _artistaRepository.Remover(idArtista, artista);
            
            return NoContent();
        }
    }
}