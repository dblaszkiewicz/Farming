using Farming.Application.Services;
using FluentValidation;

namespace Farming.Application.Commands.Validators.CommandValidators
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator(IUserReadService userReadService)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login is required")
                .MinimumLength(4).WithMessage("Login too short")
                .MustAsync(async (login, cancellation) =>
                {
                    var res = await userReadService.IsLoginUnique(login);
                    return !res;
                }).WithMessage("Login already taken");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password too short")
                .MaximumLength(15).WithMessage("Password too long")
                .Matches("[A-Z]").WithMessage("Password should have upper case letter")
                .Matches("[a-z]").WithMessage("Password should have lower case letter")
                .Matches("[0-9]").WithMessage("Password should have number");
            RuleFor(x => x.RepeatPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match");
        }
    }
}
