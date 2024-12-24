using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories.Interfaces;

namespace TaskManagementSystem.Repositories.Implementations
    {
    public class TaskRepository : GenericRepository<TaskModel>, ITaskRepository
        {
        public TaskRepository(AppDbContext context) : base(context)
            {
            }
        }
    }
