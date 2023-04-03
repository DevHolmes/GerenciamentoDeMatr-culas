using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GerenciamentoDeMatrículas.Models
{
    public class Aluno
    {
        [JsonPropertyName("cd_aluno")]
        public int cd_Aluno { get; set; }

        [Required]
        [JsonPropertyName("nome_aluno")]
        public string nome_Aluno { get; set; }

        [Required] [MaxLength(11)]
        [Range(0, int.MaxValue, ErrorMessage = "Digite apenas números para o CPF")]
        [JsonPropertyName("cpf")]
        public string cpf_Aluno { get; set; }

        [Required]
        [JsonPropertyName("foto")]
        public string url_FotoAluno { get; set; }

        [Required]
        [JsonPropertyName("dt_nascimento")]
        public DateTime dt_NascimentoAluno { get; set; }

        [Required] [EmailAddress]
        [JsonPropertyName("email")]
        public string email_Aluno { get; set; }


        public override string ToString() => JsonSerializer.Serialize<Aluno>(this);
    }
}
