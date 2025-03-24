
using System.ComponentModel.DataAnnotations;

public class Reservas
{
    public Reservas() { }
    public Reservas(Guid id, Guid idEstacionamento, Guid idVaga, Guid idUsuario, DateTime dataInicio, DateTime dataFim, StatusReservaEnum statusReserva)
    {
        Id = id;
        IdEstacionamento = idEstacionamento;
        IdVaga = idVaga;
        IdUsuario = idUsuario;
        DataInicio = dataInicio;
        DataFim = dataFim;
        StatusReserva = statusReserva;
    }

    [Key]
    public Guid Id { get; set; }
    public Guid IdEstacionamento { get; set; }
    public Guid IdVaga { get; set; }
    public Guid IdUsuario { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public StatusReservaEnum StatusReserva { get; set; }
    public string StatusReservaDescricao { get { return Enum.GetName(StatusReserva); } }
}