using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services.Interfaces
    {
    public interface ITaskService
        {
        Task<TaskModel> GetTaskByIdAsync(int id);
        Task<IEnumerable<TaskModel>> GetAllTasksAsync();
        Task AddTaskAsync(TaskModel task);
        Task UpdateTaskAsync(TaskModel task);
        Task DeleteTaskAsync(int id);
        }
    }
