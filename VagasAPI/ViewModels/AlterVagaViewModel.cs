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
            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsTrue(Enum.GetValues(typeof(StatusVagaEnum)).Cast<StatusVagaEnum>().Any(s => s == Status),
                        $"Status informado ({(int)Status}) inválido")
               .IsTrue(Enum.GetValues(typeof(TipoVagaEnum)).Cast<TipoVagaEnum>().Any(s => s == TipoVaga),
                        $"Status informado ({(int)TipoVaga}) inválido")
               .IsNotNull(TipoVaga, "O valor/hora da vaga deve ser informado")
               .IsGreaterThan(ValorHora, 0, "O valor/hora da vaga deve ser maior que 0 (zero)"));

            return new Vaga(Id, IdEstacionamento, Status, TipoVaga, ValorHora);
        }
    }
}