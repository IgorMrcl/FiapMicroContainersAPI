using NotaAPI.Domain;
using NotaAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/notas/listar", async () =>
{
    var rep = new Repository(builder.Configuration.GetConnectionString("postgres"));
    var result = await rep.ListaNotas();
    return result;
})
.WithName("ListarNotas");

app.MapPost("/nota/inserir", (Nota nota) =>
{
    var rep = new Repository(builder.Configuration.GetConnectionString("postgres"));
    rep.InsereNota(nota);
    
})
.WithName("InserirNota");

app.Run();