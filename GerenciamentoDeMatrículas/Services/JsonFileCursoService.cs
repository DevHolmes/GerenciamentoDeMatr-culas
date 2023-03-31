using GerenciamentoDeMatrículas.Models;
using System.Text.Json;

namespace GerenciamentoDeMatrículas.Services
{
    public class JsonFileCursoService
    {
        public JsonFileCursoService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Cursos.json"); }
        }

        public IEnumerable<Curso> GetAlunos()
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
    }
}
