using EmailReplyIo.Models;

namespace EmailReplyIo.Interfaces
{
    public interface IOpenAIService
    {
        Task<PromptResponse> GetOpenAIPromptAnswerAsync(string prompt, string language, string connotation);
    }
}
