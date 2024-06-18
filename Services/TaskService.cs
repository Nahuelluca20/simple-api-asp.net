using Microsoft.EntityFrameworkCore;
using my_first_api_net.Data;
using my_first_api_net.Interfaces;
using my_first_api_net.Models.Task;
using TaskModel = my_first_api_net.Models.Task.Task;

namespace my_first_api_net.Services
{
  public class TaskService(ApplicationDbContext context) : ITaskService
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<TaskModel>> GetTasksByUserIdAsync(Guid id)
    {
      return await _context.Tasks
          .Where(task => task.UserId == id)
          .ToListAsync();
    }

    public async Task<TaskModel?> GetTaskByIdAsync(Guid id)
    {
      return await _context.Tasks.FindAsync(id);
    }

    public async Task<TaskModel> CreateTaskAsync(TaskModel task)
    {
      var entityEntry = await _context.Tasks.AddAsync(task);
      await _context.SaveChangesAsync();
      return entityEntry.Entity;
    }

    public async Task<TaskModel?> UpdateTaskAsync(Guid id, UpdatedTask updatedTask)
    {
      var task = await _context.Tasks.FindAsync(id);
      if (task is null)
      {
        return null;
      }

      task.Title = updatedTask.Title ?? task.Title;
      task.Description = updatedTask.Description ?? task.Description;
      task.Date = updatedTask.Date ?? task.Date;
      task.Priority = updatedTask.Priority ?? task.Priority;
      task.DeadLine = updatedTask.DeadLine ?? task.DeadLine;
      task.CollectionId = updatedTask.CollectionId ?? task.CollectionId;
      task.UserId = updatedTask.UserId ?? task.UserId;

      await _context.SaveChangesAsync();

      return task;
    }

    public async Task<bool> DeleteTaskAsync(Guid id)
    {
      var task = await _context.Tasks.FindAsync(id);

      if (task == null)
      {
        return false;
      }

      _context.Tasks.Remove(task);
      await _context.SaveChangesAsync();

      return true;
    }
  }
}