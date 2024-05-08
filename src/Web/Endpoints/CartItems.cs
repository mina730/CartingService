using CartingService.Application.CartItems.Commands;
using CartingService.Application.CartItems.Commands.AddCartItemCommand;

namespace CartingService.Web.Endpoints;

public class CartItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(AddNewItem)
            .MapDelete(DeleteItem, "{id}");
    }

    public Task<int> AddNewItem(ISender sender, AddItemToTheCartCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> DeleteItem(ISender sender, int id)
    {
        await sender.Send(new RemoveItemCartCommand(id));
        return Results.NoContent();
    }

}
