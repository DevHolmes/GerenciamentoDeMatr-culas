using GerenciamentoDeMatrículas.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GerenciamentoDeMatrículas.Services
{
    public class DisciplinaService
    {
        public DisciplinaService(IWebHostEnvironment webHostEnvironment)
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

        public void PostDisciplina(JsonObject jdisciplina)
        {
            if (jdisciplina == null) { throw new ArgumentNullException(); }

            Disciplina disciplina = JsonSerializer.Deserialize<Disciplina>(jdisciplina);

            new DatabaseContext().NovaDisciplina(disciplina);

            return;
        }
    }
}
