using Flunt.Notifications;
using Flunt.Validations;

namespace PagamentosAPI.ViewModels
{
    public class CreatePagamentoViewModel : Notifiable<Notification>
    {
        public Guid IdReserva { get; set; }
        public Guid IdUsuario { get; set; }
        public decimal Valor { get; set; }
        public MetodoPagamentoEnum MetodoPagamento { get; set; }

        public Pagamentos MapTo()
        {
            AddNotifications(new Contract<Notification>()
                            .Requires()
                            .IsTrue(Enum.GetValues(typeof(MetodoPagamentoEnum)).Cast<MetodoPagamentoEnum>().Any(s => s == MetodoPagamento),
                                     $"Metodo de Pagamento informado ({(int)MetodoPagamento}) inválido")
                            .AreNotEquals(IdReserva, Guid.Empty, "IdReserva inválida")
                            .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario inválido")
                            .IsNotNull(Valor, "O valor do pagamento deve ser informado")
                            .IsGreaterThan(Valor, 0, "O valor do pagamento deve ser maior que 0 (zero)"));

            return new Pagamentos(Guid.NewGuid(), IdReserva, IdUsuario, Valor, MetodoPagamento);
        }
    }
}
