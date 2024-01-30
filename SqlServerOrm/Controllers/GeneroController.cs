using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlServerOrm.Domain;
using SqlServerOrm.Persistence;

namespace SqlServerOrm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            var contexto = new EduardaContext();
            var dados = contexto.Generos.ToList();

            return Ok(dados);
        }

        [HttpGet("{codigo}")]
        public IActionResult Pesquisar(int codigo)
        {
            var contexto = new EduardaContext();
            var dados = contexto.Generos.Where(ct => ct.Codigo == codigo).Include(ct => ct.Musicas).FirstOrDefault();

            return Ok(dados);
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] Genero genero)
        {
            if (genero.Tipo == null || genero.Tipo.Length <= 0 )
            {
                return BadRequest("Campo gênero é obrigatório!");
            }

            var contexto = new EduardaContext();
            contexto.Generos.Add(genero);
            contexto.SaveChanges();

            return Ok(genero);
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] Genero genero)
        {
            var contexto = new EduardaContext();
            contexto.Generos.Update(genero);
            contexto.SaveChanges();

            return Ok(genero);
        }

        [HttpDelete("codigo")]
        public IActionResult Deletar(int codigo)
        {
            var contexto = new EduardaContext();

            var genero = contexto.Generos.Where(ct => ct.Codigo == codigo).FirstOrDefault();
            if (genero != null)
            {
                contexto.Generos.Remove(genero);
                contexto.SaveChanges();
                return Ok("Gênero excluído com sucesso");
            }
            else
            {
                return NotFound("Gênero não encontrada");
            }
        }
    }
}
