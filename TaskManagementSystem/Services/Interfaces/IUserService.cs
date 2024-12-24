using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services.Interfaces
    {
    public interface IUserService
        {
        Task<UserModel> GetUserByIdAsync(int id);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task AddUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(int id);
        }
    }
