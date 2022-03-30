using FluentValidation;

namespace Farming.Application.Commands.Validators.CommandValidators
{
    public class ProcessFertilizerActionCommandValidator :
        AbstractValidator<ProcessFertilizerActionCommand>
    {
        public ProcessFertilizerActionCommandValidator()
        {
            RuleFor(c => c.LandId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.FertilizerId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.FertilizerWarehouseId)
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
