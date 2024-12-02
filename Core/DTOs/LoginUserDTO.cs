using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class LoginUserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
