using ChatGpt.API.Models.OpenAI;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using ChatGpt.API.Interfaces;

namespace ChatGpt.API.Services
{
    public class OpenAITextService : BaseOpenAIService, IOpenAITextService
    {
        public OpenAITextService(HttpClient httpClient, IOptions<OpenAIConfig> options) : base(httpClient, options)
        {
        }

        public async Task<OpenAIResponse> CompletePrompt(OpenAIRequest request)
        {
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            string json = JsonSerializer.Serialize(request, options);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("completions", content);
            string responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<OpenAIResponse>(responseContent, options);
        }
    }
}