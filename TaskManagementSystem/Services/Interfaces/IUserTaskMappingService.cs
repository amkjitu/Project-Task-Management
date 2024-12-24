using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services.Interfaces
    {
    public interface IUserTaskMappingService
        {
        Task<IEnumerable<UserTaskMappingModel>> GetAllMappingsAsync();
        Task AddMappingAsync(UserTaskMappingModel mapping);
        Task<UserTaskMappingModel?> GetMappingByIdAsync(int id); // Updated to match the implementation
        Task DeleteMappingAsync(int id);
        Task UpdateMappingAsync(UserTaskMappingModel mapping);
        }
    }

//using TaskManagementSystem.Models;

//namespace TaskManagementSystem.Services.Interfaces
//    {
//    public interface IUserTaskMappingService
//        {
//        Task AssignTaskToUserAsync(int userId, int taskId);
//        Task<IEnumerable<UserTaskMappingModel>> GetUserTaskMappingsAsync();
//        }
//    }
