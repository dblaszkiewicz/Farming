using FluentValidation;

namespace Farming.Application.Commands.Validators
{
    public class AddPesticideWarehouseDeliveryCommandValidator :
        AbstractValidator<AddPesticideWarehouseDeliveryCommand>
    {
        public AddPesticideWarehouseDeliveryCommandValidator()
        {
            RuleFor(c => c.PesticideWarehouseId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.PesticideId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be not empty");
            RuleFor(c => c.Price)
                .GreaterThan(0)
                .WithMessage("{PropertyName} should be greather than 0");
            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("{PropertyName} should be greather than 0");
        }
    }
}
