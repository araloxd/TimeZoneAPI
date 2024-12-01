using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.DTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username must not exceed 50 characters.")]
        [JsonPropertyName("username")]
        public string Username { get; set; } = "johndoe";

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        [JsonPropertyName("password")]
        public string Password { get; set; } = "SecurePass123!";

        [Required(ErrorMessage = "Time zone is required.")]
        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; } = "America/New_York";
    }
}