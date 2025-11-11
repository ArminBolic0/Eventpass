namespace EventPass.Application.DTOs.Users
{
    public class LoginResponseDto
    {
        public string token { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
}
