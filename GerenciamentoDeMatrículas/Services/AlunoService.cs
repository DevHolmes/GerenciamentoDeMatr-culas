using GerenciamentoDeMatrículas.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GerenciamentoDeMatrículas.Services
{
    public class AlunoService
    {
        public AlunoService(IWebHostEnvironment webHostEnvironment)
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

        public void PostAluno(JsonObject jaluno)
        {
            if (jaluno == null) { throw new ArgumentNullException(); }

            Aluno aluno = JsonSerializer.Deserialize<Aluno>(jaluno);

            new DatabaseContext().NovoAluno(aluno);

            return;
        }
    }
}
