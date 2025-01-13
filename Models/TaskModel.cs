namespace TaskAPI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; } // Foreign key to User
        public UserModel User { get; set; }
    }
}
