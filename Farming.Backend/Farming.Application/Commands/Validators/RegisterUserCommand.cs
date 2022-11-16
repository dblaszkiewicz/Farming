using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Validators
{
    public class RegisterUserCommand : IRequest<Response<RegisterUserResponse>>
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
