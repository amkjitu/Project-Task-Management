using TaskManagementSystem.Enums;
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

        ///new
        Task<IEnumerable<TaskModel>> FilterTasksAsync(int? userId, string? priority, string? status);
        Task<Dictionary<string, int>> GetTotalTasksByStatusAsync();
        Task<IEnumerable<TaskModel>> GetOverdueTasksAsync();
        }
    }
