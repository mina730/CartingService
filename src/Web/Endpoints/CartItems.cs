using CartingService.Application.CartItems.Commands;
using CartingService.Application.CartItems.Commands.AddCartItemCommand;
using CartingService.Application.Carts.Queries.GetCartItemsList;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Web.Endpoints;

public class CartItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(AddNewItem,"cart/{cartId}")
            .MapDelete(DeleteItem, "{id}");
    }

    public Task<int> AddNewItem(ISender sender, [FromRoute(Name = "cartId")] string cartId, AddItemToTheCartCommand command)
    {
        command.CartId = cartId;//ignore what in the object and add the item into cartId in the QueryString
        return sender.Send(command);
    }

    public async Task<IResult> DeleteItem(ISender sender, int id)
    {
        await sender.Send(new RemoveItemCartCommand(id));
        return Results.NoContent();
    }

}
