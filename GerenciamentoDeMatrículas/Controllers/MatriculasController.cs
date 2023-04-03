using GerenciamentoDeMatrículas.Models;
using GerenciamentoDeMatrículas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace GerenciamentoDeMatrículas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatriculasController : ControllerBase
    {
        public MatriculasController(MatriculaService matriculaService)
        {
            this.MatriculaService = matriculaService;
        }

        public MatriculaService MatriculaService { get; set; }


        [HttpGet("consultar")]
        public IEnumerable<Matricula> Get()
        {
            return MatriculaService.GetMatriculas();
        }

        [HttpPost("GravarMatricula")]
        public ActionResult Post([FromBody] JsonObject jmatricula)
        {
            MatriculaService.PostMatricula(jmatricula);

            return Ok();
        }
    }
}
