using System.Text.Json;
using System.Text.Json.Serialization;

namespace GerenciamentoDeMatrículas.Models
{
    public class Curso
    {
        [JsonPropertyName("cd_curso")]
        public int cd_Curso { get; set; }

        [JsonPropertyName("nome_curso")]
        public string nome_Curso { get; set; }

        [JsonPropertyName("carga_horaria")]
        public double carga_Horaria { get; set; }

        [JsonPropertyName("dt_limite_matricula")]
        public string dt_LimiteMatricula { get; set; }

        [JsonPropertyName("preco_curso")]
        public double preco_Curso { get; set; }

        [JsonPropertyName("lista_disciplinas")]
        public List<int> lista_Disciplinas { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Curso>(this);
    }
}
