using GerenciamentoDeMatrículas.Models;
using GerenciamentoDeMatrículas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciamentoDeMatrículas.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public AlunoService AlunoService;
        public IEnumerable<Aluno> Alunos { get; private set; }        

        public DisciplinaService DisciplinaService;
        public IEnumerable<Disciplina>  Disciplinas{ get; private set; }

        public MatriculaService MatriculaService;
        public IEnumerable<Matricula> Matriculas { get; private set; }


        public IndexModel(ILogger<IndexModel> logger,
            AlunoService alunoService,
            CursoService cursoService,
            DisciplinaService disciplinaService,
            MatriculaService matriculaService)
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