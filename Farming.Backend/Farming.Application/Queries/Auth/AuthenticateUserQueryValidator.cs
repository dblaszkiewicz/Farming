using FluentValidation;

namespace Farming.Application.Queries.Auth
{
    public class AuthenticateUserQueryValidator : AbstractValidator<AuthenticateUserQuery>
    {
        public AuthenticateUserQueryValidator()
        {
            RuleFor(q => q.Login)
                .NotEmpty()
                .WithMessage("Login is required")
                .MinimumLength(4).WithMessage("Invalid data");
            RuleFor(q => q.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .WithMessage("Invalid data")
                .MaximumLength(15)
                .WithMessage("Invalid data")
                .Matches("[A-Z]")
                .WithMessage("Invalid data")
                .Matches("[a-z]")
                .WithMessage("Invalid data")
                .Matches("[0-9]")
                .WithMessage("Invalid data");
        }
    }
}
