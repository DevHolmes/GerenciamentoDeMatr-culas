using GerenciamentoDeMatrículas.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GerenciamentoDeMatrículas.Services
{
    public class MatriculaService
    {
        public MatriculaService(IWebHostEnvironment webHostEnvironment)
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
                        PropertyNameCaseInsensitive = true,
                        Converters = { new DateOnlyJsonConverter() }
                    });
            }
        }

        public void PostMatricula(JsonObject jmatricula)
        {
            if (jmatricula == null) { throw new ArgumentNullException(); }

            Matricula matricula = JsonSerializer.Deserialize<Matricula>(jmatricula);

            new DatabaseContext().NovaMatricula(matricula);


            //Consulta Dados do Aluno
            Aluno aluno = new DatabaseContext().consultarAluno(matricula.cd_Aluno);

            //Consulta Cursos
            List<Curso> listaCursos = new DatabaseContext().consultarCursos(matricula.lista_Cursos);

            //Consulta Disciplinas
            List<Disciplina> listaDisciplinas = new DatabaseContext().consultarDisciplinas(matricula.lista_Cursos);


            //Monta corpo do email
            string corpoEmail = new EnvioEmail().MontarEmail(aluno, listaCursos, listaDisciplinas);            

            //Realiza envio do email
            Task envioEmail = new EnvioEmail().EnviarEmail(aluno.email_Aluno, "Comprovante de Matrícula", corpoEmail);

            return;
        }
    }
}
