using FluentValidation;

namespace Farming.Application.Commands.Validators.CommandValidators
{
    public class ProcessPesticideActionCommandValidator :
        AbstractValidator<ProcessPesticideActionCommand>
    {
        public ProcessPesticideActionCommandValidator()
        {
            RuleFor(c => c.LandId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.PesticideId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.PesticideWarehouseId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("{PropertyName} should be greather than 0");
        }
    }
}
