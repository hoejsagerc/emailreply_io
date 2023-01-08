namespace EmailReplyIo.Models
{
    public class PromptResponse
    {
        public string? Id { get; set; }
        public string? _object { get; set; }
        public int Created { get; set; }
        public string? Model { get; set; }
        public Choice[]? Choices { get; set; }
        public Usage? Usage { get; set; }
    }

    public class Usage
    {
        public int Prompt_tokens { get; set; }
        public int Completion_tokens { get; set; }
        public int Total_tokens { get; set; }
    }

    public class Choice
    {
        public string? Text { get; set; }
        public int Index { get; set; }
        public object? Logprobs { get; set; }
        public string? Finish_reason { get; set; }
    }
}
