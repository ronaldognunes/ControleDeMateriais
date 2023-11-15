using Radzen;

namespace ControleMaterialWeb.Services.Interfaces
{
    public class Recursos : IRecursos
    {
        private NotificationService _notificationService;
        public Recursos(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public void AlertaErro(string descricao = "", string tipo = "Operação realizada com sucesso")
        {
            var mensagem = new NotificationMessage
            {
                Severity = NotificationSeverity.Error,
                Summary = tipo,
                Detail = descricao,
                Duration = 4000,
                Payload = DateTime.Now
            };

            _notificationService.Notify(mensagem);
        }

        public void AlertaSucesso(string descricao = "", string tipo = "Operação não efetuada")
        {
            var mensagem = new NotificationMessage
            {
                Severity = NotificationSeverity.Success,
                Summary = tipo,
                Detail = descricao,
                Duration = 4000,
                Payload = DateTime.Now
            };

            _notificationService.Notify(mensagem);
        }
    }
}
