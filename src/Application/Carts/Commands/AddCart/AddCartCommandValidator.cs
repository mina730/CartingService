using CartingService.Application.Carts.Commands.AddCart;

namespace CartingService.Application.CartItems.Commands.AddCartItemCommand;

public class AddCartCommandValidator : AbstractValidator<AddCartCommand>
{
    public AddCartCommandValidator()
    {
        RuleFor(v => v.CartId)
            .MaximumLength(50)
            .NotEmpty();
    }
}
