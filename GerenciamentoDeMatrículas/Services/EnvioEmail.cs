using K4os.Compression.LZ4.Internal;
using Mysqlx.Session;
using System.Net.Mail;
using System.Net;
using GerenciamentoDeMatrículas.Models;

namespace GerenciamentoDeMatrículas.Services
{
    public class EnvioEmail
    {
        public string MontarEmail(Aluno aluno, List<Curso> listaCursos, List<Disciplina> listaDisciplinas)
        {
            double valorTotal = 0;

            // Constrói o corpo do e-mail em HTML usando concatenação de strings
            string body = "<html><body>" +
                          $"<img src='{aluno.url_FotoAluno}' alt='FotoAluno' width='150'>" +
                          $"<p>Olá {aluno.nome_Aluno},</p>" +
                          "<p>Segue abaixo a lista de cursos e disciplinas que você adquiriu:</p>" +
                          "<ul>";

            foreach (var curso in listaCursos)
            {
                valorTotal += curso.preco_Curso;
                body += $"<li>{curso.nome_Curso} - (";
                for (int i=0; i < listaDisciplinas.Count; i++)
                {
                    if (listaDisciplinas[i].cd_Curso == curso.cd_Curso)
                    {
                        body += $"{listaDisciplinas[i].nome_Disciplina}";
                        if (i < listaDisciplinas.Count - 1)
                            body += ", ";
                    }
                }
                
                body += ")</li>";
            }

            body += "</ul>" +
                    $"<p>Valor total: R${valorTotal.ToString("F")}</p>" +
                    "</body></html>";


            return body;
        }

        public async Task EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            DadosEmail dados = new DatabaseContext().ConsultarEmail();
            Task t = Task.Run(async () =>
            {
                using (var client = new SmtpClient())
                {
                    MailMessage msg = new MailMessage();

                    msg.From = new MailAddress(dados.email);
                    msg.To.Add(new MailAddress(destinatario));
                    msg.Body = mensagem;
                    msg.Subject = assunto;
                    msg.IsBodyHtml = true;


                    client.Host = dados.dominio;
                    client.Port = dados.porta;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(dados.email, dados.senha);


                    await client.SendMailAsync(msg);

                    return Task.FromResult(0);
                }
            });
        }       

    }
}
