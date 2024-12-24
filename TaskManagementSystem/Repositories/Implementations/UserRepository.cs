using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories.Interfaces;

namespace TaskManagementSystem.Repositories.Implementations
    {
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
        {
        public UserRepository(AppDbContext context) : base(context)
            {
            }
        }
    }
