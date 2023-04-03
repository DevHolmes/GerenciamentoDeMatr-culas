using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Mysqlx;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GerenciamentoDeMatrículas.Models
{
    public class DatabaseContext
    {
        private readonly MySqlConnection _connection;

        public DatabaseContext()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            _connection = new MySqlConnection(config.GetConnectionString("MySqlConnection"));
        }

        public DadosEmail ConsultarEmail()
        {
            DadosEmail dados = null;

            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(
                    "SELECT * from tbl_dadosemail limit 1", _connection);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    dados = new DadosEmail();
                    dados.email = reader.GetString("email");
                    dados.senha = reader.GetString("senha");
                    dados.dominio = reader.GetString("dominio");
                    dados.porta = reader.GetInt32("porta");
                }
            }
            _connection.Close();

            return dados;
        }

        public Aluno consultarAluno(int cd_aluno)
        {
            Aluno aluno = null;

            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(
                    "SELECT nm_Aluno, url_FotoAluno, email_Aluno from tbl_alunos where cd_aluno = @cd_aluno", _connection);
                    cmd.Parameters.AddWithValue("@cd_aluno", cd_aluno);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    aluno = new Aluno();
                    aluno.nome_Aluno = reader.GetString("nm_Aluno");
                    aluno.url_FotoAluno = reader.GetString("url_FotoAluno");
                    aluno.email_Aluno = reader.GetString("email_Aluno");
                }
            }
            _connection.Close();

            return aluno;
        }

        public Curso consultarCurso(int cd_curso)
        {
            Curso curso = null;

            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(
                    "SELECT nm_Curso, vl_Curso from tbl_cursos where cd_Curso = @cd_Curso", _connection);
            cmd.Parameters.AddWithValue("@cd_Curso", cd_curso);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    curso = new Curso();
                    curso.nome_Curso = reader.GetString("nm_Curso");
                    curso.preco_Curso = reader.GetDouble("vl_Curso");
                }
            }
            _connection.Close();

            return curso;
        }

        public List<Curso> consultarCursos(List<int> cd_cursos)
        {
            List<Curso> lista_cursos = new List<Curso>();
            
            string select = "SELECT cd_Curso, nm_Curso, vl_Curso from tbl_cursos where cd_Curso in (";
            
            for (int i = 0; i < cd_cursos.Count; i++)
            {
                select += cd_cursos[i].ToString();
                if (i == cd_cursos.Count - 1) { break; }
                select += ",";
            }
            select += ")";

            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(select, _connection);
            

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Curso curso = new Curso();
                    curso = new Curso();
                    curso.cd_Curso = reader.GetInt32("cd_Curso");
                    curso.nome_Curso = reader.GetString("nm_Curso");
                    curso.preco_Curso = reader.GetDouble("vl_Curso");

                    lista_cursos.Add(curso);
                }
            }
            _connection.Close();

            return lista_cursos;
        }

        public List<Disciplina> consultarDisciplinas(List<int> cd_cursos)
        {
            List<Disciplina> lista_disciplinas = new List<Disciplina>();

            string select = "SELECT cd_cursoDisciplina, nm_Disciplina from tbl_disciplinas where cd_cursoDisciplina in (";

            for (int i = 0; i < cd_cursos.Count; i++)
            {
                select += cd_cursos[i].ToString();
                if (i == cd_cursos.Count - 1) { break; }
                select += ",";
            }
            select += ")";

            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(select, _connection);            

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Disciplina disciplina = new Disciplina();
                    disciplina.cd_Curso = reader.GetInt32("cd_cursoDisciplina");
                    disciplina.nome_Disciplina = reader.GetString("nm_Disciplina");
                    lista_disciplinas.Add(disciplina);
                }
            }
            _connection.Close();

            return lista_disciplinas;
        }

        public void NovoCurso(Curso curso)
        {
            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO tbl_cursos " +
                "(nm_Curso, carga_Horaria, dt_LimiteMatricula, vl_Curso) " +
                "VALUES (@nm_curso, @carga_h, @dt_limite, @preco)"
                , _connection);
            cmd.Parameters.AddWithValue("@nm_curso", curso.nome_Curso);
            cmd.Parameters.AddWithValue("@carga_h", curso.carga_Horaria);
            cmd.Parameters.AddWithValue("@dt_limite", curso.dt_LimiteMatricula);
            cmd.Parameters.AddWithValue("@preco", curso.preco_Curso);
            cmd.ExecuteNonQuery();
            _connection.Close();
            
            return;
        }

        public void NovaDisciplina(Disciplina disciplina)
        {
            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO tbl_disciplinas " +
                "(nm_Disciplina, carga_HorDisciplina, nm_Professor, cd_cursoDisciplina) " +
                "VALUES (@nm_Disciplina, @carga_HorDisciplina, @nm_Professor, @cd_cursoDisciplina)"
                , _connection);
            cmd.Parameters.AddWithValue("@nm_Disciplina", disciplina.nome_Disciplina);
            cmd.Parameters.AddWithValue("@carga_HorDisciplina", disciplina.carga_Horaria);
            cmd.Parameters.AddWithValue("@nm_Professor", disciplina.nome_Professor);
            cmd.Parameters.AddWithValue("@cd_cursoDisciplina", disciplina.cd_Curso);
            cmd.ExecuteNonQuery();
            _connection.Close();

            return;
        }

        public void NovoAluno(Aluno aluno)
        {
            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO tbl_alunos " +
                "(nm_Aluno, cpf_Aluno, url_FotoAluno, dt_NascAluno, email_Aluno) " +
                "VALUES (@nm_Aluno, @cpf_Aluno, @url_FotoAluno, @dt_NascAluno, @email_Aluno)"
                , _connection);
            cmd.Parameters.AddWithValue("@nm_Aluno", aluno.nome_Aluno);
            cmd.Parameters.AddWithValue("@cpf_Aluno", aluno.cpf_Aluno);
            cmd.Parameters.AddWithValue("@url_FotoAluno", aluno.url_FotoAluno);
            cmd.Parameters.AddWithValue("@dt_NascAluno", aluno.dt_NascimentoAluno);
            cmd.Parameters.AddWithValue("@email_Aluno", aluno.email_Aluno);
            cmd.ExecuteNonQuery();
            _connection.Close();

            return;
        }

        public void NovaMatricula(Matricula matricula)
        {
            _connection.Open();
            foreach (var c in matricula.lista_Cursos)
            {                
                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO tbl_matriculas " +
                    "(dt_Matricula, cd_Aluno, cd_Curso) " +
                    "VALUES (@dt_Matricula, @cd_Aluno, @cd_curso)"
                    , _connection);
                cmd.Parameters.AddWithValue("@dt_Matricula", matricula.dt_Matricula);
                cmd.Parameters.AddWithValue("@cd_Aluno", matricula.cd_Aluno);
                cmd.Parameters.AddWithValue("@cd_curso", c);
                cmd.ExecuteNonQuery();
                
            }
            _connection.Close();
            return;
        }

    }
}
