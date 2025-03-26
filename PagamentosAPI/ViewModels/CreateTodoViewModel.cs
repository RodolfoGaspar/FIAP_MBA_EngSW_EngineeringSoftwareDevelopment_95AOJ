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
            //AddNotifications(new Contract<Notification>()
            //    .Requires()
            //    .IsNotNull(Title, "Informe o título da tarefa")
            //    .IsGreaterThan(Title, 5, "O título deve conter mais de 5 caracteres"));

            return new Pagamentos(Guid.NewGuid(), IdReserva, IdUsuario, Valor, MetodoPagamento);
        }
    }
}
