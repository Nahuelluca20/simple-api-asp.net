using Microsoft.AspNetCore.Http.HttpResults;
using my_first_api_net.Models.User;

namespace my_first_api_net.Controllers
{
  public static class UserController
  {
    public static WebApplication MapUserEndpoints(this WebApplication app)
    {
      app.MapGet("/users", () => "hello User");

      // app.MapGet("/users/{id:guid}", Results<Ok<User>, NotFound> (Guid id) =>
      // {
      //   return Results.Ok($"User ID: {id}");
      // });

      app.MapPost("/users", () => "post user");


      app.MapPut("/users/{id:guid}", (Guid id) =>
      {
        return Results.Ok($"Updated User ID: {id}");
      });

      app.MapDelete("/user/{id:guid}", (Guid id) =>
      {
        return Results.Ok($"Delete User ID: {id}");
      });

      return app;
    }
  }
}