using System.Text.Json;
using System.Text.Json.Serialization;

namespace GerenciamentoDeMatrículas.Models
{
    public class Disciplina
    {
        [JsonPropertyName("cd_disciplina")]
        public int cd_Disciplina { get; set; }

        [JsonPropertyName("nome_disciplina")]
        public string nome_Disciplina { get; set; }

        [JsonPropertyName("carga_horaria")]
        public double carga_Horaria { get; set; }

        [JsonPropertyName("nome_professor")] 
        public string nome_Professor { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Disciplina>(this);
    }
}
