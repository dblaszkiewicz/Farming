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
                .WithMessage("LandId should be not empty");
            RuleFor(c => c.FertilizerId)
                .NotEmpty()
                .WithMessage("FertilizerId should be not empty");
            RuleFor(c => c.FertilizerWarehouseId)
                .NotEmpty()
                .WithMessage("FertilizerWarehouseId should be not empty");
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage("UserId should be not empty");
            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity should be greather than 0");
        }
    }
}
