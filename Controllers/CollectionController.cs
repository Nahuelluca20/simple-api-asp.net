using my_first_api_net.Interfaces;
using my_first_api_net.Models.Collection;

namespace my_first_api_net.Controllers
{
  public static class CollectionController
  {
    public static WebApplication MapCollectionEndpoints(this WebApplication app)
    {

      app.MapGet("/collections/{id:guid}/tasks", async (Guid id, ICollectionService collectionService) =>
      {
        var tasks = await collectionService.GetTasksOfCollectionAsync(id);
        if (tasks == null || !tasks.Any())
        {
          return Results.NotFound();
        }
        return Results.Ok(tasks);
      });

      app.MapGet("/collections", async (ICollectionService collectionService) => await collectionService.GetCollectionsAsync());

      app.MapGet("/collections/{id:guid}", async (Guid id, ICollectionService collectionService) =>
      {
        var tasks = await collectionService.GetTasksOfCollectionAsync(id);
        if (tasks == null || !tasks.Any())
        {
          return Results.NotFound();
        }
        return Results.Ok(tasks);
      });

      app.MapPost("/collections", async (HttpContext context, ICollectionService collectionService) =>
      {
        var newCollection = await context.Request.ReadFromJsonAsync<Collection>();
        if (newCollection == null)
        {
          return Results.BadRequest("User data is null");
        }

        var createdCollection = await collectionService.CreateCollectionAsync(newCollection);
        return Results.Created($"/collections/{createdCollection.Id}", createdCollection);
      });

      app.MapPut("/collections/{id:guid}", async (HttpContext context, Guid id, ICollectionService collectionService) =>
      {
        var collectionNewInfo = await context.Request.ReadFromJsonAsync<UpdatedCollection>();
        if (collectionNewInfo == null)
        {
          return Results.BadRequest("Collection data is null");
        }

        var updatedCollection = await collectionService.UpdateCollectionAsync(id, collectionNewInfo);

        if (updatedCollection == null)
        {
          return Results.NotFound("Collection not found");
        }

        return Results.Ok(updatedCollection);
      });

      app.MapDelete("/collections/{id:guid}", async (Guid id, ICollectionService collectionService) =>
      {
        var isDeleted = await collectionService.DeleteCollectionAsync(id);

        if (!isDeleted)
        {
          return Results.NotFound($"Collection with ID {id} not found");
        }

        return Results.Ok($"Collection with ID {id} deleted successfully");
      });

      return app;
    }
  }
}