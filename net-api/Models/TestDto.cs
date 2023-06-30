using System.ComponentModel.DataAnnotations;

namespace net_api.Models
{
    public class TestDto
    {
        [Required(ErrorMessage = "Message is required.")]
        public string InputMessage { get; set; } = null!;
    }
}
