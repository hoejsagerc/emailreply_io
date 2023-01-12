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

        public async Task<PromptResponse> GetOpenAIPromptAnswerAsync(string prompt, string language, string connotation)
        {
            PromptRequest promptRequest = new PromptRequest();


            string finalPrompt = "";
            finalPrompt += "I want you to write an email response. \n";
            finalPrompt += "I want the tone of the email response to sound: " + connotation + ".\n";
            finalPrompt += "The email content is writtin in " + language + ".\n";
            finalPrompt += "I only want the answer provided in: " + language + ".\n";
            finalPrompt += "Here is the email i want you to write a reply to: \n \n" + prompt.Replace("\n", " ");

            Console.WriteLine(language);
            Console.WriteLine(connotation);
            Console.WriteLine(finalPrompt);

            promptRequest.prompt = finalPrompt;
            promptRequest.model = "text-davinci-002";
            promptRequest.max_tokens = 1500;
            promptRequest.temperature = 0;
            promptRequest.top_p = 0;

            return await _client.GetOpenAIPromptAnswerAsync(promptRequest);
        }
    }
}
 