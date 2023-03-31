using GerenciamentoDeMatrículas.Models;
using System.Text.Json;

namespace GerenciamentoDeMatrículas.Services
{
    public class JsonFileAlunoService
    {
        public JsonFileAlunoService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Alunos.json"); }
        }

        public IEnumerable<Aluno> GetAlunos()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Aluno[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters = { new DateOnlyJsonConverter() }
                    });
            }
        }
    }
}
