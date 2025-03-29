using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

public class Pagamentos
{
    public Pagamentos() { }
    public Pagamentos(Guid id, Guid idReserva, Guid idUsuario, decimal valor, MetodoPagamentoEnum metodoPagamento)
    {
        Id = id;
        IdReserva = idReserva;
        IdUsuario = idUsuario;
        Valor = valor;
        MetodoPagamento = metodoPagamento;
        StatusPagamento = StatusPagamentoEnum.PENDENTE;
        CriadoEm = DateTime.Now;
        AlteradoEm = null;
    }

    public Pagamentos(Guid id, Guid idEstacionamento, Guid idUsuario, decimal valor, MetodoPagamentoEnum metodoPagamento, DateTime alteradoEm) 
        : this(id, idEstacionamento, idUsuario, valor, metodoPagamento)
    {
        AlteradoEm = alteradoEm;
    }

    [Key]
    public Guid Id { get; set; }
    public Guid IdReserva { get; set; }
    public Guid IdUsuario { get; set; }
    public decimal Valor { get; set; }
    public MetodoPagamentoEnum MetodoPagamento { get; set; }
    [IgnoreDataMember]
    public string? MetodoPagamentoDescricao { get { return Enum.GetName(MetodoPagamento); } }
    public StatusPagamentoEnum StatusPagamento { get; set; }
    [IgnoreDataMember]
    public string? StatusPagamentoDescricao { get { return Enum.GetName(StatusPagamento); } }
    public DateTime CriadoEm { get; set; }
    public DateTime? AlteradoEm { get; set; }
}
