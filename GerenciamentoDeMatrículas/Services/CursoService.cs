using GerenciamentoDeMatrículas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GerenciamentoDeMatrículas.Services
{
    public class CursoService
    {
        public CursoService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Cursos.json"); }
        }

        public IEnumerable<Curso> GetCursos()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Curso[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void PostCurso(JsonObject jcurso)
        {
            if (jcurso == null) { throw new ArgumentNullException(); }

            Curso curso = JsonSerializer.Deserialize<Curso>(jcurso);

            new DatabaseContext().NovoCurso(curso);

            return;
        }
    }
}
