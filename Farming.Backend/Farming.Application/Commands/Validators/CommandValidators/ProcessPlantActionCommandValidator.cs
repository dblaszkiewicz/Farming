using FluentValidation;

namespace Farming.Application.Commands.Validators.CommandValidators
{
    public class ProcessPlantActionCommandValidator :
        AbstractValidator<ProcessPlantActionCommand>
    {
        public ProcessPlantActionCommandValidator()
        {
            RuleFor(c => c.LandId)
                .NotEmpty()
                .WithMessage("LandId should be not empty");
            RuleFor(c => c.PlantId)
                .NotEmpty()
                .WithMessage("PlantId should be not empty");
            RuleFor(c => c.PlantWarehouseId)
                .NotEmpty()
                .WithMessage("PlantWarehouseId should be not empty");
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage("UserId should be not empty");
            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity should be greather than 0");
        }
    }
}
