using GerenciamentoDeMatrículas.Models;
using GerenciamentoDeMatrículas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciamentoDeMatrículas.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public JsonFileAlunoService AlunoService;
        public IEnumerable<Aluno> Alunos { get; private set; }

        public JsonFileCursoService CursoService;
        public IEnumerable<Curso> Cursos { get; private set; }

        public JsonFileDisciplinaService DisciplinaService;
        public IEnumerable<Disciplina>  Disciplinas{ get; private set; }

        public JsonFileMatriculaService MatriculaService;
        public IEnumerable<Matricula> Matriculas { get; private set; }


        public IndexModel(ILogger<IndexModel> logger,
            JsonFileAlunoService alunoService,
            JsonFileCursoService cursoService,
            JsonFileDisciplinaService disciplinaService,
            JsonFileMatriculaService matriculaService)
        {
            _logger = logger;
            AlunoService = alunoService;
        }

        public void OnGet()
        {
            Alunos = AlunoService.GetAlunos();
        }
    }
}