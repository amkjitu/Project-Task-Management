using System.Data;
using TaskManagementSystem.Enums;

namespace TaskManagementSystem.Models
    {
    public class UserModel
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        }
    }
