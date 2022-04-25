
namespace Farming.Application.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
