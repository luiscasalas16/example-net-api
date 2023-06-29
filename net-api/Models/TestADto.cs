using System.ComponentModel.DataAnnotations;

namespace net_api.Models
{
    public class TestADto
    {
        [Required(ErrorMessage = "Message is required.")]
        public string InputMessage { get; set; } = null!;
    }
}
