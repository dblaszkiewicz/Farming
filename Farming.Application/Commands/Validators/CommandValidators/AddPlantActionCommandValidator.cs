using FluentValidation;

namespace Farming.Application.Commands.Validators.CommandValidators
{
    public class AddPlantActionCommandValidator :
        AbstractValidator<AddPlantActionCommand>
    {
        public AddPlantActionCommandValidator()
        {
            RuleFor(c => c.LandId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.PlantId)
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
