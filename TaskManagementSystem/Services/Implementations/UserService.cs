using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories.Interfaces;
using TaskManagementSystem.Services.Interfaces;

namespace TaskManagementSystem.Services.Implementations
    {
    public class UserService : IUserService
        {
        //private readonly IUserRepository _userRepository;
        private readonly IGenericRepository<UserModel> _userRepository;

        public UserService(IGenericRepository<UserModel> userRepository)
            {
            _userRepository = userRepository;
            }

        public async Task<UserModel> GetUserByIdAsync(int id)
            {
            return await _userRepository.GetByIdAsync(id);
            }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
            {
            return await _userRepository.GetAllAsync();
            }

        public async Task AddUserAsync(UserModel user)
            {
            await _userRepository.AddAsync(user);
            }

        public async Task UpdateUserAsync(UserModel user)
            {
            await _userRepository.UpdateAsync(user);
            }

        public async Task DeleteUserAsync(int id)
            {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
                {
                await _userRepository.DeleteAsync(user);
                }
            }
        }
    }
