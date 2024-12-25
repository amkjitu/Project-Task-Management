using TaskManagementSystem.Enums;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories.Interfaces;
using TaskManagementSystem.Services.Interfaces;

namespace TaskManagementSystem.Services.Implementations
    {
    public class TaskService : ITaskService
        {
        //private readonly ITaskRepository _taskRepository;
        private readonly IGenericRepository<UserTaskMappingModel> _mappingRepository;
        private readonly IGenericRepository<TaskModel> _taskRepository;

        public TaskService(IGenericRepository<TaskModel> taskRepository, IGenericRepository<UserTaskMappingModel> mappingRepository)
            {
            _taskRepository = taskRepository;
            _mappingRepository = mappingRepository;
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


        ///new
        public async Task<IEnumerable<TaskModel>> FilterTasksAsync(int? userId, string? priority, string? status)
            {
            var tasks = await _taskRepository.GetAllAsync();

            if (userId.HasValue)
                {
                var userTaskIds = (await _mappingRepository.GetAllAsync())
                    .Where(mapping => mapping.UserId == userId.Value)
                    .Select(mapping => mapping.TaskId);
                tasks = tasks.Where(task => userTaskIds.Contains(task.Id));
                }

            if (!string.IsNullOrEmpty(priority))
                {
                tasks = tasks.Where(task => task.Priority.ToString() == priority);
                }

            if (!string.IsNullOrEmpty(status))
                {
                tasks = tasks.Where(task => task.Status.ToString() == status);
                }

            return tasks;
            }

        public async Task<Dictionary<string, int>> GetTotalTasksByStatusAsync()
            {
            var tasks = await _taskRepository.GetAllAsync();
            return tasks
                .GroupBy(task => task.Status.ToString())
                .ToDictionary(group => group.Key, group => group.Count());
            }

        public async Task<IEnumerable<TaskModel>> GetOverdueTasksAsync()
            {
            var tasks = await _taskRepository.GetAllAsync();
            return tasks.Where(task => task.DueDate < DateTime.Now && task.Status != Status.Completed);
            }
        }
    }
