using System.ComponentModel.DataAnnotations;

namespace netfw_api.Models
{
    public class TestEntityDto
    {
        [Required(ErrorMessage = "FistName is required.")]
        public string FistName { get; set; } = null;

        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; } = null;

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = null;
    }
}
