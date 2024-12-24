using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories.Interfaces;
using TaskManagementSystem.Services.Interfaces;

namespace TaskManagementSystem.Services.Implementations
    {
    public class TaskService : ITaskService
        {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
            {
            _taskRepository = taskRepository;
            }

        public async Task<TaskModel> GetTaskByIdAsync(int id)
            {
            return await _taskRepository.GetByIdAsync(id);
            }

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
            {
            return await _taskRepository.GetAllAsync();
            }

        public async Task AddTaskAsync(TaskModel task)
            {
            await _taskRepository.AddAsync(task);
            }

        public async Task UpdateTaskAsync(TaskModel task)
            {
            await _taskRepository.UpdateAsync(task);
            }

        public async Task DeleteTaskAsync(int id)
            {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task != null)
                {
                await _taskRepository.DeleteAsync(task);
                }
            }
        }
    }
