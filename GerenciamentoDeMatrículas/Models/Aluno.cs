using System.Text.Json;
using System.Text.Json.Serialization;

namespace GerenciamentoDeMatrículas.Models
{
    public class Aluno
    {
        [JsonPropertyName("cd_aluno")]
        public int cd_Aluno { get; set; }


        [JsonPropertyName("nome_aluno")]
        public string nome_Aluno { get; set; }


        [JsonPropertyName("cpf")]
        public string cpf_Aluno { get; set; }


        [JsonPropertyName("foto")]
        public string url_FotoAluno { get; set; }


        [JsonPropertyName("dt_nascimento")]
        public DateOnly dt_NascimentoAluno { get; set; }


        [JsonPropertyName("email")]
        public string email_Aluno { get; set; }


        public override string ToString() => JsonSerializer.Serialize<Aluno>(this);
    }
}
