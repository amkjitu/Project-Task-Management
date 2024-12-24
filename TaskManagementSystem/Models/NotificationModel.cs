namespace TaskManagementSystem.Models
    {
    public class NotificationModel
        {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        }
    }