using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<UserTask> UserTasks { get; set; }
        public ICollection<TaskCategory> TaskCategories { get; set; }
    }
}
