using FluentValidation;
using TestTask.WebApi.Contracts.Requests;

namespace TestTask.WebApi.Validators
{
    public class UpdateSingleOrderRequestValidator : AbstractValidator<UpdateSingleOrderRequest>
    {
        public UpdateSingleOrderRequestValidator()
        {
            RuleFor(model => model.Material)
                .NotEmpty()
                .Length(1, 40);
            RuleFor(model => model.Quantity).PrecisionScale(8, 3, true);
        }
    }
}
