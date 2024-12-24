using System;
using TaskManagementSystem.Enums;

namespace TaskManagementSystem.Models
    {
    public class TaskModel
        {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime DueDate { get; set; }
        }
    }
