using System.ComponentModel.DataAnnotations;

namespace WebIVBackend.Domain.Models
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public LoginRequest()
        {
            
        }
    }
}