
namespace Farming.Application.Requests
{
    public class RegisterUserDto
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
