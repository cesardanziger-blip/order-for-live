using FluentValidation;
using OrderForLiveTest.Application.DTOs.Requests;

namespace OrderForLiveTest.Application.Validators
{
    public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemRequest>
    {
        public CreateOrderItemValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Product name is required");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero");
        }
    }
}