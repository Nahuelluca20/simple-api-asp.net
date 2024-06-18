using my_first_api_net.Interfaces;
using my_first_api_net.Models.Task;
using TaskModel = my_first_api_net.Models.Task.Task;

namespace my_first_api_net.Controllers
{
  public static class TaskController
  {
    public static WebApplication MapTaskEndpoints(this WebApplication app)
    {

      app.MapGet("/tasks/users/{id:guid}", async (Guid id, ITaskService taskService) =>
      {
        var task = await taskService.GetTasksByUserIdAsync(id);

        return task == null ? Results.NotFound() : Results.Ok(task);
      });

      app.MapGet("/tasks/{id:guid}", async (Guid id, ITaskService taskService) =>
      {
        var task = await taskService.GetTaskByIdAsync(id);

        return task == null ? Results.NotFound() : Results.Ok(task);
      });


      app.MapPost("/tasks", async (HttpContext context, TaskModel task, ITaskService taskService) =>
      {
        var newTask = await context.Request.ReadFromJsonAsync<TaskModel>();
        if (newTask == null)
        {
          return Results.BadRequest("Task data is null");
        }

        var createdTask = await taskService.CreateTaskAsync(newTask);
        return Results.Created($"/tasks/{createdTask.Id}", createdTask);
      });

      app.MapPut("/tasks/{id:guid}", async (HttpContext context, Guid id, ITaskService taskService) =>
      {

        var taskNewInfo = await context.Request.ReadFromJsonAsync<UpdatedTask>();
        if (taskNewInfo == null)
        {
          return Results.BadRequest("Task data is null");
        }

        var updatedTask = await taskService.UpdateTaskAsync(id, taskNewInfo);

        if (updatedTask == null)
        {
          return Results.NotFound("Task not found");
        }

        return Results.Ok(updatedTask);
      });

      app.MapDelete("/tasks/{id:guid}", async (Guid id, ITaskService taskService) =>
      {
        var isDeleted = await taskService.DeleteTaskAsync(id);

        if (!isDeleted)
        {
          return Results.NotFound($"Task with ID {id} not found");
        }

        return Results.Ok($"Task with ID {id} deleted successfully");
      });


      return app;
    }

  }
}