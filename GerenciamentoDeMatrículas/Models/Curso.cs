using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GerenciamentoDeMatrículas.Models
{
    public class Curso
    {
        [JsonPropertyName("cd_curso")]
        public int cd_Curso { get; set; }

        [Required]
        [JsonPropertyName("nome_curso")]
        public string nome_Curso { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Carga horária deve ser numérica")]
        [JsonPropertyName("carga_horaria")]
        public double carga_Horaria { get; set; }

        [Required]
        [JsonPropertyName("dt_limite_matricula")]
        public DateTime dt_LimiteMatricula { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Valor do Curso deve ser numérico")]
        [JsonPropertyName("preco_curso")]
        public double preco_Curso { get; set; }

        [Required]
        [JsonPropertyName("lista_disciplinas")]
        public List<int> lista_Disciplinas { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Curso>(this);
    }
}
