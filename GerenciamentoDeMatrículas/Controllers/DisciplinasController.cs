using GerenciamentoDeMatrículas.Models;
using GerenciamentoDeMatrículas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace GerenciamentoDeMatrículas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {
        public DisciplinasController(DisciplinaService disciplinaService)
        {
            this.DisciplinaService = disciplinaService;
        }

        public DisciplinaService DisciplinaService { get; set; }


        [HttpGet("consultar")]
        public IEnumerable<Disciplina> Get()
        {
            return DisciplinaService.GetDisciplinas();
        }

        [HttpPost("GravarDisciplina")]
        public ActionResult Post([FromBody] JsonObject jdisciplina)
        {
            DisciplinaService.PostDisciplina(jdisciplina);

            return Ok();
        }
    }
}
