using Flunt.Notifications;

public class AlterPagamentoViewModel : Notifiable<Notification>
{
    public Guid Id { get; set; }
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

        return new Pagamentos(Id, IdReserva, IdUsuario, Valor, MetodoPagamento, DateTime.Now);
    }
}