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
    public TipoVagaEnum TipoVaga { get; set; }
    public decimal ValorHora { get; set; }
}
