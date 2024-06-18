using my_first_api_net.Models.Task;
using TaskModel = my_first_api_net.Models.Task.Task;

namespace my_first_api_net.Interfaces

{
  public interface ITaskService
  {
    Task<IEnumerable<TaskModel>> GetTasksByUserIdAsync(Guid id);

    Task<TaskModel?> GetTaskByIdAsync(Guid id);

    Task<TaskModel> CreateTaskAsync(TaskModel task);

    Task<TaskModel?> UpdateTaskAsync(Guid id, UpdatedTask updatedTask);

    Task<bool> DeleteTaskAsync(Guid id);

  }
}