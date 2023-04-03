using GerenciamentoDeMatrículas.Models;
using GerenciamentoDeMatrículas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GerenciamentoDeMatrículas.Pages
{
    public class CadastroCursoModel : PageModel
    {
        private readonly ILogger<CadastroCursoModel> _logger;

        [BindProperty]
        public Curso NovoCurso { get; set; }

        public CursoService CursoService;
        public IEnumerable<Curso> Cursos { get; private set; }

        public CadastroCursoModel(ILogger<CadastroCursoModel> logger,
            CursoService cursoService)
        {
            _logger = logger;
            CursoService = cursoService;
        }

        public void OnGet()
        {
            Cursos = CursoService.GetCursos();
        }

        public async void OnPost()
        {
            Curso curso = NovoCurso;

            var json = JsonSerializer.Serialize<Curso>(curso);

            var client = new HttpClient();
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("https://localhost:7143/cursos/GravarCurso", content);

            var value = await response.Content.ReadAsStringAsync();

        }
    }
}
