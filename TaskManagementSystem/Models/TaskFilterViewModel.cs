using System.Collections.Generic;

namespace TaskManagementSystem.Models
    {
    public class TaskFilterViewModel
        {
        public int? AssigneeId { get; set; }
        public TaskPriority? Priority { get; set; }
        public TaskStatus? Status { get; set; }

        public List<UserModel> Assignees { get; set; } = new List<UserModel>();
        public List<TaskModel> FilteredTasks { get; set; } = new List<TaskModel>();
        }
    }
