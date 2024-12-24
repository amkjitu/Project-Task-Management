using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
    {
    public class AppDbContext : DbContext
        {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

        public DbSet<UserTaskMappingModel> UserTaskMappings { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<NotificationModel> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            base.OnModelCreating(modelBuilder);

            // Defining composite unique constraint on TaskId and UserId
            modelBuilder.Entity<UserTaskMappingModel>()
                .HasIndex(utm => new { utm.TaskId, utm.UserId })
                .IsUnique();

            // Defining the relationships for UserTaskMappingModel
            modelBuilder.Entity<UserTaskMappingModel>()
                .HasOne(utm => utm.Task)
                .WithMany()  // A task can be assigned to many users
                .HasForeignKey(utm => utm.TaskId)
                .OnDelete(DeleteBehavior.Cascade);  // Define the delete behavior (optional)

            modelBuilder.Entity<UserTaskMappingModel>()
                .HasOne(utm => utm.User)
                .WithMany()  // A user can be assigned many tasks
                .HasForeignKey(utm => utm.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // Define the delete behavior (optional)
            }
        }
    }


//using Microsoft.EntityFrameworkCore;
//using TaskManagementSystem.Models;

//namespace TaskManagementSystem.Data
//    {
//    public class AppDbContext : DbContext
//        {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//        public DbSet<UserModel> Users { get; set; }
//        public DbSet<TaskModel> Tasks { get; set; }
//        public DbSet<UserTaskMappingModel> UserTaskMappings { get; set; }
//        public DbSet<NotificationModel> Notifications { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//            {
//            // Configure UserTaskMapping many-to-many relationship
//            modelBuilder.Entity<UserTaskMappingModel>()
//                .HasKey(ut => new { ut.UserId, ut.TaskId });

//            modelBuilder.Entity<UserTaskMappingModel>()
//                .HasOne(ut => ut.User)
//                .WithMany()
//                .HasForeignKey(ut => ut.UserId);

//            modelBuilder.Entity<UserTaskMappingModel>()
//                .HasOne(ut => ut.Task)
//                .WithMany()
//                .HasForeignKey(ut => ut.TaskId);

//            base.OnModelCreating(modelBuilder);
//            }
//        }
//    }

