using Microsoft.AspNetCore.Mvc;

namespace Sistema_Bancario_Sprint3.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class LivroController : Controller
    {
        [HttpGet]
        public IActionResult GetLivros()
        {
            var livros = new List<string>
            {
                "Livro 1",
                "Livro 2",
                "Livro 3"
            };
            return Ok(livros);
        }

        [HttpGet("bemVindo")]
        public IActionResult GetBemVindo()
        {
            return Ok("Bem-vindo à API de Livros!");
        }
    }
}
