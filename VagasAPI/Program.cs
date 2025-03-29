using VagasApi.Data;
using VagasApi.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Habilita o CORS na aplicação
app.UseCors("PermitirTudo");

app.MapGet("/v1/vagas", (AppDbContext context) =>
{
    var vagas = context.Vagas?.ToList();
    return vagas is not null
        ? Results.Ok(new { vagas })
        : Results.NotFound();
}).Produces<object>();

app.MapGet("/v1/vagas/{id}", (string id, AppDbContext context) =>
{
    if (Guid.TryParse(id, out Guid idVaga))
    {
        var vagas = context?.Vagas?.FirstOrDefault(v => v.Id == Guid.Parse(id));
        return vagas is not null ? Results.Ok(vagas) : Results.NotFound();
    }
    return Results.NotFound();
}).Produces<Vaga>();

app.MapPost("/v1/vagas", (AppDbContext context, CreateVagaViewModel model) =>
{
    var vaga = model.MapTo();
    if (!model.IsValid)
    {
        return Results.BadRequest(model.Notifications);
    }

    context?.Vagas?.Add(vaga);
    context?.SaveChanges();

    return Results.Created($"/v1/vagas/{vaga.Id}", vaga);
});

app.MapPut("/v1/vagas", (AppDbContext context, AlterVagaViewModel model) =>
{
    var modelVaga = model.MapTo();
    if (!model.IsValid)
    {
        return Results.BadRequest(model.Notifications);
    }

    var vaga = context?.Vagas?.FirstOrDefault(v => v.Id == model.Id);

    if (vaga is not null)
    {
        vaga.IdEstacionamento = model.IdEstacionamento;
        vaga.Status = model.Status;
        vaga.TipoVaga = model.TipoVaga;
        vaga.ValorHora = model.ValorHora;

        context?.SaveChanges();
        return Results.Created($"/v1/vagas/{modelVaga.Id}", modelVaga);
    }

    return Results.NoContent();
});

app.MapGet("/v1/vagas/status", (AppDbContext context) =>
{
    return Enum.GetValues(typeof(StatusVagaEnum))
               .Cast<StatusVagaEnum>()
               .Select(s => new { Id = s, Name = Enum.GetName(s) })
               .ToList();
}).Produces<dynamic>();

app.MapGet("/v1/vagas/tipos", (AppDbContext context) =>
{
    return Enum.GetValues(typeof(TipoVagaEnum))
               .Cast<TipoVagaEnum>()
               .Select(s => new { Id = s, Name = Enum.GetName(s) })
               .ToList();
}).Produces<dynamic>();

app.Run();
