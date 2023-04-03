using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GerenciamentoDeMatrículas.Models
{
    public class Matricula
    {
        [JsonPropertyName("cd_matricula")]
        public int cd_Matricula { get; set; }

        [Required]
        [JsonPropertyName("dt_matricula")]
        public DateTime dt_Matricula { get; set; }

        [Required]
        [JsonPropertyName("cd_aluno")]
        public int cd_Aluno { get; set; }

        [Required]
        [JsonPropertyName("lista_cursos")]
        public List<int> lista_Cursos{ get; set; }

        public override string ToString() => JsonSerializer.Serialize<Matricula>(this);
    }
}
