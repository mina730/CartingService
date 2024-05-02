using CartingService.Application.CartItems.Commands;
using CartingService.Application.Carts.Queries.GetCartItemsList;
using CartingService.Application.Common.Exceptions;
using CartingService.Domain.Entities;

namespace CartingService.Application.FunctionalTests.TodoItems.Commands;

using static Testing;

public class AddCartItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new AddItemToTheCartCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldAddCartItem()
    {
        var userId = await RunAsDefaultUserAsync();

        var listId = await SendAsync(new AddCartCommand
        {
            CartId = "Cart Id"
        });

        var command = new AddItemToTheCartCommand
        {
            CartId = listId,
            ImageText = "Image Text",
            ImageURL="Image URL",
            Name = "Name",
            Price=10,
            Quantity=2
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<Item>(itemId);

        item.Should().NotBeNull();
        item!.CartId.Should().Be(command.CartId);
        item.Name.Should().Be(command.Name);
        item.ImageText.Should().Be(command.ImageText);
        item.ImageURL.Should().Be(command.ImageURL);
        item.Price.Should().Be(command.Price);
        item.Quantity.Should().Be(command.Quantity);
        item.CreatedBy.Should().Be(userId);
        item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
