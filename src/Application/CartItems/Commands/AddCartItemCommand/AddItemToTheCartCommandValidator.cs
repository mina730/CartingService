namespace CartingService.Application.CartItems.Commands.AddCartItemCommand;

public class AddItemToTheCartCommandValidator : AbstractValidator<AddItemToTheCartCommand>
{
    public AddItemToTheCartCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotEmpty();
        RuleFor(v => v.Quantity)
            .GreaterThan(0);
        RuleFor(v => v.Price)
            .GreaterThanOrEqualTo(0);
    }
}
