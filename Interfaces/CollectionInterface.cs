using my_first_api_net.Models.Collection;
using TaskModel = my_first_api_net.Models.Task.Task;

namespace my_first_api_net.Interfaces
{
  public interface ICollectionService
  {
    Task<IEnumerable<TaskModel>> GetTasksOfCollectionAsync(Guid id);
    Task<IEnumerable<Collection>> GetCollectionsAsync();
    Task<Collection?> GetCollectionById(Guid id);
    Task<Collection> CreateCollectionAsync(Collection collection);
    Task<Collection?> UpdateCollectionAsync(Guid id, UpdatedCollection updatedCollection);
    Task<bool> DeleteCollectionAsync(Guid id);

  }
}