using ChatGpt.API.Models.OpenAI;

namespace ChatGpt.API.Interfaces
{
    public interface IOpenAITextService
    {
        Task<OpenAIResponse> CompletePrompt(OpenAIRequest request);
    }
}