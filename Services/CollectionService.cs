using Microsoft.EntityFrameworkCore;
using my_first_api_net.Data;
using my_first_api_net.Interfaces;
using my_first_api_net.Models.Collection;
using TaskModel = my_first_api_net.Models.Task.Task;

namespace my_first_api_net.Services
{
  public class CollectionService(ApplicationDbContext context) : ICollectionService
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<TaskModel>> GetTasksOfCollectionAsync(Guid id)
    {
      return await _context.Tasks
          .Where(task => task.CollectionId == id)
          .ToListAsync();
    }
    public async Task<IEnumerable<Collection>> GetCollectionsAsync()
    {
      return await _context.Collections.ToListAsync();
    }

    public async Task<Collection?> GetCollectionById(Guid id)
    {
      return await _context.Collections.FindAsync(id);
    }
    public async Task<Collection> CreateCollectionAsync(Collection collection)
    {
      var entityEntry = await _context.Collections.AddAsync(collection);
      await _context.SaveChangesAsync();
      return entityEntry.Entity;
    }

    public async Task<Collection?> UpdateCollectionAsync(Guid id, UpdatedCollection updatedCollection)
    {
      var collection = await _context.Collections.FindAsync(id);
      if (collection is null)
      {
        return null;
      }

      collection.Name = updatedCollection.Name ?? collection.Name;
      collection.Banner = updatedCollection.Banner ?? collection.Banner;

      await _context.SaveChangesAsync();

      return collection;
    }

    public async Task<bool> DeleteCollectionAsync(Guid id)
    {
      var collection = await _context.Collections.FindAsync(id);

      if (collection == null)
      {
        return false;
      }

      _context.Collections.Remove(collection);
      await _context.SaveChangesAsync();

      return true;
    }
  }
}