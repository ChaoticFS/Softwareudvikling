using Notit.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;
using Thread = Notit.Shared.Models.Thread;

namespace Notit.Client.Services
{
    public class ThreadService
    {
        private readonly HttpClient httpClient;

        public ThreadService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Thread> GetThread (int id) 
        {
            var result = httpClient.GetFromJsonAsync<Thread>($"api/thread?id={id}");
            return result;
        }
        public Task PostThread(Thread thread)
        {
            httpClient.PostAsJsonAsync<Thread>($"api/thread", thread);
            return Task.CompletedTask;
        }

        public Task PutThread(Thread thread)
        {
            httpClient.PutAsJsonAsync<Thread>($"api/thread", thread);
            return Task.CompletedTask;
        }

        public Task DeleteThread(Thread thread)
        {
            string parameters = JsonSerializer.Serialize(thread);
            httpClient.DeleteAsync($"api/thread?parameters={parameters}");
            return Task.CompletedTask;
        }

        public Task<Thread[]> GetFrontPage()
        {
            var result = httpClient.GetFromJsonAsync<Thread[]>($"api/thread/frontpage");
            return result;
        }
    }
}
