using System.ComponentModel.DataAnnotations;

namespace netfw_api.Models
{
    public class TestADto
    {
        [Required(ErrorMessage = "Message is required.")]
        public string InputMessage { get; set; } = null;
    }
}
