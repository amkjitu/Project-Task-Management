using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories.Interfaces;

namespace TaskManagementSystem.Repositories.Implementations
    {
    public class UserTaskMappingRepository : GenericRepository<UserTaskMappingModel>, IUserTaskMappingRepository
        {
        public UserTaskMappingRepository(AppDbContext context) : base(context)
            {
            }
        }
    }
