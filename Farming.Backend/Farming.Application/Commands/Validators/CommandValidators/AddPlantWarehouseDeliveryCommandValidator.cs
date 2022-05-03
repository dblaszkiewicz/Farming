using FluentValidation;

namespace Farming.Application.Commands.Validators.CommandValidators
{
    public class AddPlantWarehouseDeliveryCommandValidator :
        AbstractValidator<AddPlantWarehouseDeliveryCommand>
    {
        public AddPlantWarehouseDeliveryCommandValidator()
        {
            RuleFor(c => c.PlantWarehouseId)
                .NotEmpty()
                .WithMessage("PlantWarehouseId should be not empty");
            RuleFor(c => c.PlantId)
                .NotEmpty()
                .WithMessage("PlantId should be not empty");
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage("UserId should be not empty");
            RuleFor(c => c.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price should be greather than or equal to 0");
            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity should be greather than 0");
        }
    }
}
