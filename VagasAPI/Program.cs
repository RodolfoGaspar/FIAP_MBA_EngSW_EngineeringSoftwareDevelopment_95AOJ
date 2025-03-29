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
        var vaga = context?.Vagas?.FirstOrDefault(v => v.Id == Guid.Parse(id));
        return vaga is not null ? Results.Ok(vaga) : Results.NotFound();
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

app.MapDelete("/v1/vagas/{id}", (string id, AppDbContext context) =>
{
    if (Guid.TryParse(id, out Guid idVaga))
    {
        var vaga = context?.Vagas?.FirstOrDefault(v => v.Id == idVaga);
        if (vaga is not null)
        {
            context?.Remove(vaga);
            if (context?.SaveChanges() > 0)
            { return Results.NoContent(); }
        }
    }
    return Results.NotFound();
});

app.MapGet("/v1/vagas/status", () =>
{
    return Enum.GetValues(typeof(StatusVagaEnum))
               .Cast<StatusVagaEnum>()
               .Select(s => new { Id = s, Name = Enum.GetName(s) })
               .ToList();
}).Produces<dynamic>();

app.MapGet("/v1/vagas/tipos", () =>
{
    return Enum.GetValues(typeof(TipoVagaEnum))
               .Cast<TipoVagaEnum>()
               .Select(s => new { Id = s, Name = Enum.GetName(s) })
               .ToList();
}).Produces<dynamic>();

app.MapGet("/v1/estacionamentos", () =>
{
    var estacionamenos = new List<dynamic>
    {
        new { Id = "a080010f-6774-485c-826c-4e8a9c7896a1", Nome = "Estaciona Fácil" },
        new { Id = "35e38ce9-bd33-4152-8df6-f8f6415a1027", Nome = "Park & Go" },
        new { Id = "849adfa0-a25a-4aac-ae3d-c1db9e965b91", Nome = "Vaga Certa" },
        new { Id = "5584a759-e39a-4fef-8c2d-30cafbf0c4cc", Nome = "Espaço Flex" },
        new { Id = "fbbcc5a7-5900-46e6-b8b5-878c6292bd47", Nome = "Drive Park" }
    };

    return Results.Ok(new { estacionamenos });
}).Produces<object>();

app.Run();
