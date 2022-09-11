namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IEnvioDeEmailService
    {
        Task EnviarEmail(string destinatario, string assunto, string menssagem);
    }
}
