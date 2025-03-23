public class Vaga
{
    public Vaga() { }
    public Vaga(Guid id, Guid idEstacionamento, StatusVagaEnum status, TipoVagaEnum tipoVaga, decimal valorHora)
    {
        Id = id;
        IdEstacionamento = idEstacionamento;
        Status = status;
        TipoVaga = tipoVaga;
        ValorHora = valorHora;
    }

    public Guid Id { get; set; }
    public Guid IdEstacionamento { get; set; }
    public StatusVagaEnum Status { get; set; }
    public string StatusDescricao { get { return Enum.GetName(Status); } }
    public TipoVagaEnum TipoVaga { get; set; }
    public string TipoVagaDescricao { get { return Enum.GetName(TipoVaga); } }
    public decimal ValorHora { get; set; }
}
