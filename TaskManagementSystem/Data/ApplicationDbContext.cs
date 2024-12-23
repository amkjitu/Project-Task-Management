using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
    {
    public class ApplicationDbContext : DbContext
        {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserTaskMappingModel> UserTaskMappings { get; set; }
        }
    }
