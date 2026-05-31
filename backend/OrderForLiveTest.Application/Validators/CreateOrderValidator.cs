using FluentValidation;
using OrderForLiveTest.Application.DTOs.Requests;

namespace OrderForLiveTest.Application.Validators
{
    public class CreateOrderValidator: AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Customer name is required");

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("Order must have items");

            RuleForEach(x => x.Items)
                .SetValidator(new CreateOrderItemValidator());
        }
    }
}