using FluentValidation;

namespace Farming.Application.Commands.Validators.CommandValidators
{
    public class AddPesticideWarehouseDeliveryCommandValidator :
        AbstractValidator<AddPesticideWarehouseDeliveryCommand>
    {
        public AddPesticideWarehouseDeliveryCommandValidator()
        {
            RuleFor(c => c.PesticideWarehouseId)
                .NotEmpty()
                .WithMessage("PesticideWarehouseId should be not empty");
            RuleFor(c => c.PesticideId)
                .NotEmpty()
                .WithMessage("PesticideId should be not empty");
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage("UserId should be not empty");
            RuleFor(c => c.Price)
                .GreaterThan(0)
                .WithMessage("Price should be greather than 0");
            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity should be greather than 0");
        }
    }
}
