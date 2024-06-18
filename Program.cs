using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using my_first_api_net.Controllers;
using my_first_api_net.Data;
using my_first_api_net.Interfaces;
using my_first_api_net.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<ITaskService, TaskService>();

static string HelloWord()
{
  return "Hello word";
}

Env.Load();

// Read Envs
var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
var db = Environment.GetEnvironmentVariable("POSTGRES_DB");
var user = Environment.GetEnvironmentVariable("POSTGRES_USER");
var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

// Create string for db connection
var connectionString = $"Host={host};Database={db};Username={user};Password={password}";

// Setup DbContext for use PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.MapGet("/", HelloWord);
app.MapUserEndpoints();
app.MapCollectionEndpoints();
app.MapTaskEndpoints();

app.Run();
