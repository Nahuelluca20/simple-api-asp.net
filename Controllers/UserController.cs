using Microsoft.AspNetCore.Http.HttpResults;
using my_first_api_net.Interfaces;
using my_first_api_net.Models.User;
using my_first_api_net.Services;

namespace my_first_api_net.Controllers
{
  public static class UserController
  {
    public static WebApplication MapUserEndpoints(this WebApplication app)
    {
      app.MapGet("/users", async (IUserService userService) =>
        await userService.GetAllUsersAsync()
      );

      app.MapGet("/users/{id:guid}", async (Guid id, IUserService userService) =>
      {
        var user = await userService.GetUserById(id);

        return user == null ? Results.NotFound() : Results.Ok(user);

      });

      app.MapPost("/users", async (HttpContext context, IUserService userService) =>
      {
        var user = await context.Request.ReadFromJsonAsync<User>();
        if (user == null)
        {
          return Results.BadRequest("User data is null");
        }

        var createdUser = await userService.CreateUserAsync(user);
        return Results.Created($"/users/{createdUser.Id}", createdUser);
      });


      app.MapPut("/users/{id:guid}", async (Guid id, HttpContext context, IUserService userService) =>
      {
        var userNewInfo = await context.Request.ReadFromJsonAsync<UpdatedUser>();
        if (userNewInfo == null)
        {
          return Results.BadRequest("User data is null");
        }

        var updatedUser = await userService.UpdateUserAsync(id, userNewInfo);

        if (updatedUser == null)
        {
          return Results.NotFound("User not found");
        }

        return Results.Ok(updatedUser);
      });

      app.MapDelete("/user/{id:guid}", async (Guid id, IUserService userService) =>
      {
        var isDeleted = await userService.DeleteUserAsync(id);

        if (!isDeleted)
        {
          return Results.NotFound($"User with ID {id} not found");
        }

        return Results.Ok($"User with ID {id} deleted successfully");
      });

      return app;
    }
  }
}