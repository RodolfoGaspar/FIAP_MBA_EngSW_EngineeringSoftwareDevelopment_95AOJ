using Flunt.Notifications;
using Flunt.Validations;

namespace VagasApi.ViewModels
{
    public class CreateVagaViewModel : Notifiable<Notification>
    {
        public Guid IdEstacionamento { get; set; }
        public StatusVagaEnum Status { get; set; }
        public TipoVagaEnum TipoVaga { get; set; }
        public decimal ValorHora { get; set; }

        public Vaga MapTo()
        {
            //AddNotifications(new Contract<Notification>()
            //    .Requires()
            //    .IsNotNull(TipoVaga, "Informe o título da tarefa")
            //    .IsGreaterThan(TipoVaga, 5, "O título deve conter mais de 5 caracteres"));

            return new Vaga(Guid.NewGuid(), IdEstacionamento, Status, TipoVaga, ValorHora);
        }
    }
}
