using Flunt.Notifications;
using Flunt.Validations;

namespace VagasApi.ViewModels
{
    public class AlterVagaViewModel : Notifiable<Notification>
    {
        public Guid Id { get; set; }
        public Guid IdEstacionamento { get; set; }
        public StatusVagaEnum Status { get; set; }
        public TipoVagaEnum TipoVaga { get; set; }
        public decimal ValorHora { get; set; }

        public Vaga MapTo()
        {
            //AddNotifications(new Contract<Notification>()
            //    .Requires()
            //    .IsNotNull(TipoVaga, "Informe o t�tulo da tarefa")
            //    .IsGreaterThan(TipoVaga, 5, "O t�tulo deve conter mais de 5 caracteres"));

            return new Vaga(Guid.NewGuid(), IdEstacionamento, Status, TipoVaga, ValorHora);
        }
    }
}