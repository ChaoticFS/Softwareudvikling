using System;
using Thread = Notit.Shared.Models.Thread;

namespace Notit.Shared.Models
{
    public class Comment
    {
        public Comment()
        {
        }

        public Comment(string text, string user, DateTime date) 
        { 
            Text = text;
            User = user;
            Date = date;
        }
        public Comment(string text, string user)
        {
            Text = text;
            User = user;
            Date = DateTime.Now;
        }

        public long CommentId { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; } = 0;

        public Thread Thread { get; set; } = new Thread("", "");
    }
}