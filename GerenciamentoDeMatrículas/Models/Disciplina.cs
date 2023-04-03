using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GerenciamentoDeMatrículas.Models
{
    public class Disciplina
    {
        [JsonPropertyName("cd_disciplina")]
        public int cd_Disciplina { get; set; }

        [Required]
        [JsonPropertyName("nome_disciplina")]
        public string nome_Disciplina { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Carga horária deve ser numérica")]
        [JsonPropertyName("carga_horaria")]
        public double carga_Horaria { get; set; }

        [Required]
        [JsonPropertyName("nome_professor")] 
        public string nome_Professor { get; set; }

        [JsonPropertyName("cd_Curso")]
        public int cd_Curso { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Disciplina>(this);
    }
}
