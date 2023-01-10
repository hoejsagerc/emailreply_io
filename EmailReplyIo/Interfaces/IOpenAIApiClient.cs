using EmailReplyIo.Models;

namespace EmailReplyIo.Interfaces
{
    public interface IOpenAIApiClient
    {
        Task<PromptResponse> GetOpenAIPromptAnswerAsync(PromptRequest prompt);
    }
}
