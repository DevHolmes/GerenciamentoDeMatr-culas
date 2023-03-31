using GerenciamentoDeMatrículas.Models;
using System.Text.Json;

namespace GerenciamentoDeMatrículas.Services
{
    public class JsonFileDisciplinaService
    {
        public JsonFileDisciplinaService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Disciplinas.json"); }
        }

        public IEnumerable<Disciplina> GetDisciplinas()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Disciplina[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
