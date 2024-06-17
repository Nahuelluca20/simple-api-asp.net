using my_first_api_net.Controllers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

static string HelloWord()
{
  return "Hello word";
}

app.MapGet("/", HelloWord);
app.MapUserEndpoints();

app.Run();
