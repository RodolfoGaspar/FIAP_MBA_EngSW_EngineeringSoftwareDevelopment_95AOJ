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
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsTrue(Enum.GetValues(typeof(StatusReservaEnum)).Cast<StatusReservaEnum>().Any(s => s == StatusReserva),
                        $"Status informado ({(int)StatusReserva}) inválido")
                .AreNotEquals(IdEstacionamento, Guid.Empty, "IdEstacionamento inválido")
                .AreNotEquals(IdVaga, Guid.Empty, "IdVaga inválido")
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario inválido")
                .IsGreaterThan(DataInicio, DateTime.Now.AddDays(1), "Reserva deve ser realizada com pelo menos um dia de antecedencia")
                .IsGreaterThan(DataInicio, DateTime.MinValue, "O inicio da reserva deve ser informado")
                .IsLowerThan(DataInicio, DateTime.MaxValue, "Data de inicio da reserva inválida")
                .IsGreaterThan(DataFim, DateTime.MinValue, "O final da reserva deve ser informado")
                .IsLowerThan(DataFim, DateTime.MaxValue, "Data final da reserva inválida")
                .IsGreaterThan(DataFim, DataInicio, "O final da reserva deve ser posterior à data inicial")
                .IsGreaterThan(DataFim, DateTime.Now, "O final da reserva deve ser posterior à data de atual"));

            return new Reservas(Id, IdEstacionamento, IdVaga, IdUsuario, DataInicio, DataFim, StatusReserva);
        }
    }
}
