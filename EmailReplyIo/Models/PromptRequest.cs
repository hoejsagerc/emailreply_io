using System.ComponentModel.DataAnnotations;

namespace EmailReplyIo.Models
{
    public class PromptRequest
    {
        public string model { get; set; }

        [Required, StringLength(700)]
        public string prompt { get; set; }

        public int temperature { get; set; }

        public int max_tokens { get; set; }

        public PromptRequest()
        {
            this.model = "text-davinci-003";

            this.prompt = "Write this is a test";
            
            this.temperature = 0;

            this.max_tokens = 1000;
        }
    }
}
