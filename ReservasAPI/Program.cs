using ReservasAPI.Data;
using ReservasAPI.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/v1/reservas", (AppDbContext context) =>
{
    var reservas = context.Reservas;
    return reservas is not null ? Results.Ok(reservas) : Results.NotFound();
}).Produces<Reservas>();

app.MapGet("/v1/reservas/{id}", (string id, AppDbContext context) =>
{
    if (Guid.TryParse(id, out Guid idReserva))
    {
        var reservas = context.Reservas.FirstOrDefault(v => v.Id == Guid.Parse(id));
        return reservas is not null ? Results.Ok(reservas) : Results.NotFound();
    }
    return Results.NotFound();
}).Produces<Reservas>();

app.MapPost("/v1/reservas", (AppDbContext context, CreateReservaViewModel model) =>
{
    var reserva = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    context.Reservas.Add(reserva);
    context.SaveChanges();

    return Results.Created($"/v1/reservas/{reserva.Id}", reserva);
});

app.MapPut("/v1/reservas", (AppDbContext context, AlterReservaViewModel model) =>
{
    var modelReserva = model.MapTo();
    if (!model.IsValid)
    { return Results.BadRequest(model.Notifications); }

    var reserva = context.Reservas.FirstOrDefault(v => v.Id == model.Id);

    if (reserva is not null)
    {
        reserva.IdEstacionamento = model.IdEstacionamento;
        reserva.IdVaga = model.IdVaga;
        reserva.IdUsuario = model.IdUsuario;
        reserva.DataInicio = model.DataInicio;
        reserva.DataFim = model.DataFim;
        reserva.StatusReserva = model.StatusReserva;

        context.SaveChanges();
        return Results.Created($"/v1/vagas/{modelReserva.Id}", modelReserva);
    }

    return Results.NoContent();
});

app.MapGet("/v1/reservas/status", (AppDbContext context) =>
{
    return Enum.GetValues(typeof(StatusReservaEnum)).Cast<StatusReservaEnum>().Select(s => new { Id = s, Name = Enum.GetName(s) }).ToList();

}).Produces<dynamic>();

app.Run();
