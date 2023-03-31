using GerenciamentoDeMatrículas.Models;
using System.Text.Json;

namespace GerenciamentoDeMatrículas.Services
{
    public class JsonFileMatriculaService
    {
        public JsonFileMatriculaService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Matriculas.json"); }
        }

        public IEnumerable<Matricula> GetMatriculas()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Matricula[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
