using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class AddUserCommand : IRequest<Response<AddUserResponse>>
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public Guid CurrentUserId { get; set; }

        public AddUserCommand(string login, string name, string password, string repeatPassword, Guid currentUserId)
        {
            Login = login;
            Name = name;
            Password = password;
            RepeatPassword = repeatPassword;
            CurrentUserId = currentUserId;
        }
    }
}
