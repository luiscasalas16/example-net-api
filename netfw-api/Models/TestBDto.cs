using System.ComponentModel.DataAnnotations;

namespace netfw_api.Models
{
    public class TestBDto
    {
        [Required(ErrorMessage = "Message is required.")]
        public string InputMessage { get; set; } = null;
    }
}
