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

var connString = builder.Configuration.GetConnectionString("postgres");
var senhaDB = builder.Configuration.GetValue<string>("DB_PASSWORD");

app.MapGet("/notas/listar", async () =>
{
    var rep = new Repository(connString.Replace("$$password$$", senhaDB));
    var result = await rep.ListaNotas();
    return result;
})
.WithName("ListarNotas");

app.MapPost("/nota/inserir", (Nota nota) =>
{
    var rep = new Repository(connString.Replace("$$password$$", senhaDB));
    rep.InsereNota(nota);
    
})
.WithName("InserirNota");

app.Run();