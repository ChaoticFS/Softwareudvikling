using Notit.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Notit.Client.Services
{
    public class CommentService
    {
        private readonly HttpClient httpClient;

        public CommentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Comment> GetComment(int commentId)
        {
            var result = httpClient.GetFromJsonAsync<Comment>($"api/comment?id={commentId}");
            return result;
        }

        public Task PostComment(Comment comment)
        {
            httpClient.PostAsJsonAsync<Comment>("api/comment", comment);
            return Task.CompletedTask;
        }

        public Task PutComment(Comment comment)
        {
            httpClient.PutAsJsonAsync<Comment>("api/comment", comment);
            return Task.CompletedTask;
        }

        public Task DeleteComment(Comment comment)
        {
            string parameters = JsonSerializer.Serialize(comment);
            httpClient.DeleteAsync($"api/comment?parameters={parameters}");
            return Task.CompletedTask;
        }

        public Task<Comment[]> GetComments(int threadid)
        {
            var result = httpClient.GetFromJsonAsync<Comment[]>($"api/comment/comments?threadid={threadid}");
            return result;
        }
    }
}