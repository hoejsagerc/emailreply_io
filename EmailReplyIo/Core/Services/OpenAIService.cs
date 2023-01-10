using EmailReplyIo.Interfaces;
using EmailReplyIo.Models;

namespace EmailReplyIo.Core.Services
{
    public class OpenAIService : IOpenAIService
    {                   
        private readonly IOpenAIApiClient _client;
        public OpenAIService(IOpenAIApiClient client)
        {
            _client = client;
        }

        public async Task<PromptResponse> GetOpenAIPromptAnswerAsync(string prompt)
        {
            PromptRequest promptRequest = new PromptRequest();

            promptRequest.prompt = prompt;
            promptRequest.model = "text-davinci-002";
            promptRequest.max_tokens = 500;
            promptRequest.temperature = 0;

            return await _client.GetOpenAIPromptAnswerAsync(promptRequest);
        }
    }
}
