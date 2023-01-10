using EmailReplyIo.Interfaces;
using EmailReplyIo.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace EmailReplyIo.Core.HttpClients
{
    public class OpenAIApiClient : IOpenAIApiClient
    {
        private readonly HttpClient _client;
        private readonly string? _apiKey;

        public OpenAIApiClient(HttpClient client)
        {
            _client = client;
            _apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        }

        public async Task<PromptResponse> GetOpenAIPromptAnswerAsync(PromptRequest prompt)
        {
            var content = new StringContent(JsonConvert.SerializeObject(prompt));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _client.PostAsync("https://api.openai.com/v1/completions", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            };

            var deserializedJson = JsonConvert.DeserializeObject<PromptResponse>(responseContent, settings);

            if (response.IsSuccessStatusCode && deserializedJson != null)
            {
                return deserializedJson;
            }
            else
            {
                throw new Exception(responseContent);
            }
        }
    }
}
