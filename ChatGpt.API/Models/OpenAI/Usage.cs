namespace ChatGpt.API.Models.OpenAI
{
    public class Usage
    {
        public int PromptTokens { get; set; }

        public int CompletionTokens { get; set; }

        public int TotalTokens { get; set; }
    }
}