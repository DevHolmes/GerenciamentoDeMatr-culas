using GerenciamentoDeMatrículas.Models;
using GerenciamentoDeMatrículas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace GerenciamentoDeMatrículas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        public AlunosController(AlunoService alunoService)
        {
            this.AlunoService = alunoService;
        }

        public AlunoService AlunoService { get; set; }


        [HttpGet("consultar")]
        public IEnumerable<Aluno> Get()
        {
            return AlunoService.GetAlunos();
        }

        [HttpPost("GravarAluno")]
        public ActionResult Post([FromBody] JsonObject jaluno)
        {
            AlunoService.PostAluno(jaluno);

            return Ok();
        }
    }
}
