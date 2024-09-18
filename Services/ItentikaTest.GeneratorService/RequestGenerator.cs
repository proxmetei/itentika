using ItentikaTest.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ItentikaTest.Services.Generate
{
    /// <summary>
    /// Метод для отправки запроса на процессор (сервис)
    /// </summary>
    public static class RequestGenerator
    {
        private const string path = "http://localhost:5126/api/Process";
        public static void SendRequest(Event myEvent)
        {
            var client = new HttpClient();
            var myContent = JsonSerializer.Serialize(myEvent);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            client.PostAsync(path, byteContent);
        }
    }
}
