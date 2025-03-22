using VagasApi.Data;
using VagasApi.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/v1/vagas", (AppDbContext context) =>
{
    var vagas = context.Vagas;
    return vagas is not null ? Results.Ok(vagas) : Results.NotFound();
}).Produces<Vaga>();

app.MapPost("/v1/vagas", (AppDbContext context, CreateTodoViewModel model) =>
{
    var vaga = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    context.Vagas.Add(vaga);
    context.SaveChanges();

    return Results.Created($"/v1/vagas/{vaga.Id}", vaga);
});

app.Run();
