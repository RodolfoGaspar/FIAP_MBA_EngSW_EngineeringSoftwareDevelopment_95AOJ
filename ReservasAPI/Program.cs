using ReservasAPI.Data;
using ReservasAPI.ViewModels;

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

app.UseCors("PermitirTudo");

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/v1/reservas", (AppDbContext context) =>
{
    var reservas = context.Reservas;
    return reservas is not null ? Results.Ok(new { reservas }) : Results.NotFound();
}).Produces<object>();

app.MapGet("/v1/reservas/{id}", (string id, AppDbContext context) =>
{
    if (Guid.TryParse(id, out Guid idReserva))
    {
        var reservas = context?.Reservas?.FirstOrDefault(r => r.Id == idReserva);
        return reservas is not null ? Results.Ok(reservas) : Results.NotFound();
    }
    return Results.NotFound();
}).Produces<Reservas>();

app.MapPost("/v1/reservas", (AppDbContext context, CreateReservaViewModel model) =>
{
    var reserva = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    context?.Reservas?.Add(reserva);
    context?.SaveChanges();

    return Results.Created($"/v1/reservas/{reserva.Id}", reserva);
});

app.MapPut("/v1/reservas", (AppDbContext context, AlterReservaViewModel model) =>
{
    var modelReserva = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    var reserva = context?.Reservas?.FirstOrDefault(r => r.Id == model.Id);

    if (reserva is not null)
    {
        reserva.IdEstacionamento = model.IdEstacionamento;
        reserva.IdVaga = model.IdVaga;
        reserva.IdUsuario = model.IdUsuario;
        reserva.DataInicio = model.DataInicio;
        reserva.DataFim = model.DataFim;
        reserva.StatusReserva = model.StatusReserva;

        context?.SaveChanges();
        return Results.Created($"/v1/reservas/{modelReserva.Id}", modelReserva);
    }

    return Results.NoContent();
});

app.MapDelete("/v1/reservas/{id}", (string id, AppDbContext context) =>
{
    if (Guid.TryParse(id, out Guid idReserva))
    {
        var reserva = context?.Reservas?.FirstOrDefault(r => r.Id == idReserva);
        if (reserva is not null)
        {
            context?.Remove(reserva);
            if (context?.SaveChanges() > 0)
                return Results.NoContent();
        }
    }
    return Results.NotFound();
});

app.MapPut("/v1/reservas/cancelar/{id}", (string id, AppDbContext context) =>
{
    if (Guid.TryParse(id, out Guid idReserva))
    {
        var reserva = context?.Reservas?.FirstOrDefault(r => r.Id == idReserva);
        if (reserva is not null)
        {
            reserva.StatusReserva = StatusReservaEnum.CANCELADA;
            context?.SaveChanges();
            return Results.Created($"/v1/reservas/{id}", reserva);
        }
    }
    return Results.NotFound();
});

app.MapGet("/v1/reservas/status", () =>
{
    return Enum.GetValues(typeof(StatusReservaEnum))
               .Cast<StatusReservaEnum>()
               .Select(s => new { Id = s, Name = Enum.GetName(s) })
               .ToList();
}).Produces<dynamic>();

app.Run();
