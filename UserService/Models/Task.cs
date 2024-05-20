namespace UserService.Models
{
    public class Task
    {
        public int taskID { get; set; }

        public string? taskTitle { get; set; }

        public string? description { get; set; }

        public DateTime? dateCreate { get; set; }

        public DateTime? Deadline { get; set; }

        public int? status { get; set; }

        public int? LichthamId { get; set; }

        public int? commnetID { get; set; }

        

    }
}
