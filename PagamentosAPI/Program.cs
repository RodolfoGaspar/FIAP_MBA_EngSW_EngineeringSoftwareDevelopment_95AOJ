using PagamentosAPI.Data;
using PagamentosAPI.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Habilita o CORS na aplicação
app.UseCors("PermitirTudo");

app.MapGet("/v1/pagamentos", (AppDbContext context) =>
{
    var pagamentos = context.Pagamentos;
    return pagamentos is not null ? Results.Ok(new { pagamentos }) : Results.NotFound();
}).Produces<Pagamentos>();

app.MapGet("/v1/pagamentos/{id}", (string id, AppDbContext context) =>
{
    if (Guid.TryParse(id, out Guid idReserva))
    {
        var reservas = context?.Pagamentos?.FirstOrDefault(p => p.Id == Guid.Parse(id));
        return reservas is not null ? Results.Ok(reservas) : Results.NotFound();
    }
    return Results.NotFound();
}).Produces<Pagamentos>();

app.MapPost("/v1/pagamentos", (AppDbContext context, CreatePagamentoViewModel model) =>
{
    var pagamento = model.MapTo();
    if (!model.IsValid)
    { return Results.BadRequest(model.Notifications); }

    context?.Pagamentos?.Add(pagamento);
    context?.SaveChanges();

    return Results.Created($"/v1/pagamentos/{pagamento.Id}", pagamento);
});

app.MapPut("/v1/pagamentos", (AppDbContext context, AlterPagamentoViewModel model) =>
{
    var modelReserva = model.MapTo();
    if (!model.IsValid)
    { return Results.BadRequest(model.Notifications); }

    var reserva = context?.Pagamentos?.FirstOrDefault(p => p.Id == model.Id);

    if (reserva is not null)
    {
        reserva.IdReserva = model.IdReserva;
        reserva.IdUsuario = model.IdUsuario;
        reserva.Valor = model.Valor;
        reserva.MetodoPagamento = model.MetodoPagamento;

        context?.SaveChanges();
        return Results.Created($"/v1/reservas/{modelReserva.Id}", modelReserva);
    }

    return Results.NoContent();
});

app.MapDelete("/v1/pagamentos/{id}", (string id, AppDbContext context) =>
{
    if (Guid.TryParse(id, out Guid idReserva))
    {
        var reserva = context?.Pagamentos?.FirstOrDefault(p => p.Id == idReserva);
        if (reserva is not null)
        {
            context?.Remove(reserva);
            if (context?.SaveChanges() > 0)
            { return Results.NoContent(); }
        }
    }
    return Results.NotFound();
});

app.MapGet("/v1/pagamentos/metodos", () =>
{
    return Enum.GetValues(typeof(MetodoPagamentoEnum)).Cast<MetodoPagamentoEnum>().Select(s => new { Id = s, Name = Enum.GetName(s) }).ToList();
}).Produces<dynamic>();

app.MapGet("/v1/pagamentos/status", () =>
{
    return Enum.GetValues(typeof(StatusPagamentoEnum)).Cast<StatusPagamentoEnum>().Select(s => new { Id = s, Name = Enum.GetName(s) }).ToList();
}).Produces<dynamic>();

app.Run();
