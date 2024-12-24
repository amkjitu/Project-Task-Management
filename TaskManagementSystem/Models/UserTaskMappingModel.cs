namespace TaskManagementSystem.Models
    {
    public class UserTaskMappingModel
        {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public TaskModel Task { get; set; }  

        public int UserId { get; set; }
        public UserModel User { get; set; }  // Navigation property

        public DateTime AssignedAt { get; set; } = DateTime.Now;
        }
    }
