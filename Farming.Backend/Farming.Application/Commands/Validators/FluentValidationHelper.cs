using FluentValidation.Results;

namespace Farming.Application.Commands.Validators
{
    public static class FluentValidationHelper
    {
        public static string GetExceptionMessage(ValidationResult validationResult)
        {
            return validationResult.Errors.First().ErrorMessage;
        }
    }
}
