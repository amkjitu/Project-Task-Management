using System;

namespace TaskManagementSystem.Models
    {
    public class TaskModel
        {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        }
    }
