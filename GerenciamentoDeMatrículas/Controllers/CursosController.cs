using GerenciamentoDeMatrículas.Models;
using GerenciamentoDeMatrículas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GerenciamentoDeMatrículas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        public CursosController(CursoService cursoService)
        {
            this.CursoService = cursoService;
        }

        public CursoService CursoService { get; set; }


        [HttpGet("consultar")]
         public IEnumerable<Curso> Get()
        {
            return CursoService.GetCursos();
        }

        [HttpPost("GravarCurso")]
        public ActionResult Post([FromBody]JsonObject jcurso)
        {
            CursoService.PostCurso(jcurso);

            return Ok();
        }

    }
}
