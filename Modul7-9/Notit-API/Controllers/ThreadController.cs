using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notit.API.Models;
using Notit.Shared.Models;
using System.Text.Json;
using Thread = Notit.Shared.Models.Thread;

namespace Notit.API.Controllers
{
    [Route("api/thread")]
    [ApiController]
    public class ThreadController : ControllerBase
    { //Should absolutely change this to call on a repository instead but i am lazy
        private NotitContext Db { get; }

        public ThreadController(NotitContext db) 
        {  
            Db = db; 
        }

        [HttpGet]
        public Thread Get(long id)
        {
            return Db.Threads.Find(id);
        }

        [HttpPost]
        public void Post(Thread thread)
        {
            Db.Threads.Add(thread);
            Db.SaveChanges();
        }

        [HttpPut]
        public void Put(Thread thread)
        {
            Db.Threads.Update(thread);
            Db.SaveChanges();
        }

        [HttpDelete]
        public void Delete(string parameters)
        {
            Thread thread = JsonSerializer.Deserialize<Thread>(parameters);
            Db.Threads.Remove(thread);
            Db.SaveChanges();
        }

        [HttpGet("frontpage")]
        public List<Thread> GetFrontPage()
        {
            var result = Db.Threads
                .OrderByDescending(t => t.Date)
                .Take(50)
                .ToList();

            return result;
        }

        public bool IsSeeded()
        {
            Thread? thread = Db.Threads.FirstOrDefault();
            if (thread == null)
            {
                return false;
            }
            return true;
        }
    }
}
