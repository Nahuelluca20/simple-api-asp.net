using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using my_first_api_net.Controllers;
using my_first_api_net.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

static string HelloWord()
{
  return "Hello word";
}

Env.Load();

// Leer las variables de entorno
var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
var db = Environment.GetEnvironmentVariable("POSTGRES_DB");
var user = Environment.GetEnvironmentVariable("POSTGRES_USER");
var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

// Construir la cadena de conexión utilizando las variables de entorno
var connectionString = $"Host={host};Database={db};Username={user};Password={password}";

// Configurar el DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

app.MapGet("/", HelloWord);
app.MapUserEndpoints();

app.Run();
