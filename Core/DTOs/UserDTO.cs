namespace Core.DTOs
{
    public class UserDTO: BaseDTO
    {
        public string Username { get; set; } = string.Empty;
        public string TimeZone { get; set; } = "UTC";
        public string PasswordHash { get; set; } = string.Empty;
    }
}
