namespace Models
{
    public class TodoTask
    {
        public TodoTask(string text, string category, User user, bool done)
        {
            this.Text = text;
            this.Category = category;
            this.User = user;
            this.Done = done;
        }

        public TodoTask(string text, string category, bool done)
        {
            this.Text = text;
            this.Category = category;
            this.Done = done;
        }
        public long TodoTaskId { get; set; }
        public string? Text { get; set; }
        public string? Category { get; set; }
        public bool Done { get; set; }
        public User User { get; set; }
    }
}