using Flunt.Notifications;
using Flunt.Validations;

namespace ReservasAPI.ViewModels
{
    public class AlterReservaViewModel : Notifiable<Notification>
    {
        public Guid Id { get; set; }
        public Guid IdEstacionamento { get; set; }
        public Guid IdVaga { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public StatusReservaEnum StatusReserva { get; set; }

        public Reservas MapTo()
        {
            //AddNotifications(new Contract<Notification>()
            //    .Requires()
            //    .IsNotNull(Title, "Informe o título da tarefa")
            //    .IsGreaterThan(Title, 5, "O título deve conter mais de 5 caracteres"));

            return new Reservas(Id, IdEstacionamento, IdVaga, IdUsuario, DataInicio, DataFim, StatusReserva);
        }
    }
}
