using FluentValidation;

namespace Farming.Application.Commands.Validators
{
    public class AddPlantWarehouseDeliveryCommandValidator :
        AbstractValidator<AddPlantWarehouseDeliveryCommand>
    {
        public AddPlantWarehouseDeliveryCommandValidator()
        {
            RuleFor(c => c.PlantWarehouseId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.PlantId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} should be greather than or equal to 0");
            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("{PropertyName} should be greather than 0");
        }
    }
}
