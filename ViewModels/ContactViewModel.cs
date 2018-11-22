
using System.ComponentModel.DataAnnotations;

namespace emptProj.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Message is too long")]
        public string Message { get; set; }
    }
}
