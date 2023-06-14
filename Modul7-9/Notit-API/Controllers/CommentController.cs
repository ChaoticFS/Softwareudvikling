using Microsoft.AspNetCore.Mvc;
using Notit.API.Models;
using Notit.Shared.Models;
using System.Text.Json;

namespace Notit.API.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    { //Should absolutely change this to call on a repository instead but i am lazy
        private NotitContext Db { get; }

        public CommentController(NotitContext db)
        {
            Db = db;
        }

        [HttpGet]
        public Comment Get(long id)
        {
            return Db.Comments.Find(id);
        }

        [HttpPost]
        public void Post(Comment comment)
        {
            Db.Comments.Add(comment);
            Db.SaveChanges();
        }

        [HttpPut]
        public void Put(Comment comment)
        {
            Db.Comments.Update(comment);
            Db.SaveChanges();
        }

        [HttpDelete]
        public void Delete(string parameters)
        {
            Comment comment = JsonSerializer.Deserialize<Comment>(parameters);
            Db.Comments.Remove(comment);
            Db.SaveChanges();
        }

        [HttpGet("comments")]
        public List<Comment> GetComments(int threadid)
        {
            return Db.Comments.Where(c => c.Thread.ThreadId == threadid).ToList();
        }
    }
}
