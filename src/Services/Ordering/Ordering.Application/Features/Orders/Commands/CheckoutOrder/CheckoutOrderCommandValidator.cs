using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    class CheckoutOrderCommandValidator:AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{UserName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{UserName} must not 50 characters");
            RuleFor(p => p.EmailAdress)
                .NotEmpty().WithMessage("{EmailAdress} is required.");

            RuleFor(p => p.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");


        }
    }
}
