using ControleMateriaisApi.Configurations;
using ControleMateriaisApi.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace ControleMateriaisApi.Services
{
    public class EnvioDeEmailService : IEnvioDeEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EnvioDeEmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        
        public async Task EnviarEmail(string destinatario, string assunto, string menssagem)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Controle de Materiais", _emailSettings.UsernameEmail));
                message.To.Add(new MailboxAddress("cliente",destinatario));
                message.Subject = "Resetar Senha";

                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = menssagem
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort, SecureSocketOptions.StartTls);
                    client.Authenticate(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    await client.SendAsync(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
