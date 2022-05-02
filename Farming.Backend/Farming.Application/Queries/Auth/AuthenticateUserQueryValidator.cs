using FluentValidation;

namespace Farming.Application.Queries.Auth
{
    public class AuthenticateUserQueryValidator : AbstractValidator<AuthenticateUserQuery>
    {
        public AuthenticateUserQueryValidator()
        {
            RuleFor(q => q.Login)
                .NotEmpty()
                .WithMessage("Login jest wymagany")
                .MinimumLength(4).WithMessage("Nieprawidłowe dane");
            RuleFor(q => q.Password)
                .NotEmpty()
                .WithMessage("Hasło jest wymagane")
                .MinimumLength(6)
                .WithMessage("Nieprawidłowe dane")
                .MaximumLength(15)
                .WithMessage("Nieprawidłowe dane")
                .Matches("[A-Z]")
                .WithMessage("Nieprawidłowe dane")
                .Matches("[a-z]")
                .WithMessage("Nieprawidłowe dane")
                .Matches("[0-9]")
                .WithMessage("Nieprawidłowe dane");
        }
    }
}
