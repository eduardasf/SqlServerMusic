using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlServerOrm.Domain;
using SqlServerOrm.Persistence;

namespace SqlServerOrm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            var contexto = new EduardaContext();
            var dados = contexto.Musicas.OrderBy(c => c.Nome).ToList();

            return Ok(dados);
        }

        [HttpGet("codigo")]
        public IActionResult Pesquisar(int codigo)
        {
            var contexto = new EduardaContext();
            var dados = contexto.Musicas.Where(c => c.Codigo == codigo).Include(c => c.Genero).ToList();

            return Ok(dados);
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] Musica musica)
        {
            var contexto = new EduardaContext();
            contexto.Musicas.Add(musica);
            contexto.SaveChanges();

            return Ok(musica);
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] Musica musica)
        {
            var contexto = new EduardaContext();
            contexto.Update(musica);
            contexto.SaveChanges();

            return Ok(musica);
        }

        [HttpDelete("{codigo}")]
        public IActionResult Deletar(int codigo)
        {
            var contexto = new EduardaContext();

            var musica = contexto.Musicas.Where(c => c.Codigo == codigo).FirstOrDefault();

            if (musica != null)
            {
                contexto.Musicas.Remove(musica);
                contexto.SaveChanges();
            }
            else
            {
                return NotFound("Música não encontrada");
            }

            return Ok("Música excluída com sucesso");
        }

    }
}
