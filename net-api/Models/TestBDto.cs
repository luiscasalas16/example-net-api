using System.ComponentModel.DataAnnotations;

namespace net_api.Models
{
    public class TestBDto
    {
        [Required(ErrorMessage = "Message is required.")]
        public string InputMessage { get; set; } = null!;
    }
}
