
namespace Farming.Domain.ValueObjects.User
{

    public record UserIsAdmin
    {
        public bool Value { get; }

        public UserIsAdmin(bool value)
        {
            Value = value;
        }

        public static implicit operator bool(UserIsAdmin isAdmin)
            => isAdmin.Value;

        public static implicit operator UserIsAdmin(bool isAdmin)
            => new(isAdmin);
    }
}
