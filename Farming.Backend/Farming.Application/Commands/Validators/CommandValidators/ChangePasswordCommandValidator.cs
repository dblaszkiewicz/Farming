using FluentValidation;

namespace Farming.Application.Commands.Validators.CommandValidators
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Old password is required");
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password too short")
                .MaximumLength(15).WithMessage("Password too long")
                .Matches("[A-Z]").WithMessage("Password should have upper case letter")
                .Matches("[a-z]").WithMessage("Password should have lower case letter")
                .Matches("[0-9]").WithMessage("Password should have number");
            RuleFor(x => x.RepeatNewPassword)
                .Equal(x => x.NewPassword).WithMessage("Passwords do not match");
        }
    }
}
