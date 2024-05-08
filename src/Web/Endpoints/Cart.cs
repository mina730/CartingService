
using CartingService.Application.Carts.Commands.AddCart;
using CartingService.Application.Carts.Queries.GetCartItemsList;
using CartingService.Application.Common.Models;

namespace CartingService.Web.Endpoints;

public class Cart : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCartItems,"{cartId}")
            .MapPost(AddCart);
    }
    public Task<CartDto> GetCartItems(ISender sender, [AsParameters] GetCartItemsQuery query)
    {
        return sender.Send(query);
    }
    public Task<string?> AddCart(ISender sender, AddCartCommand command)
    {
        return sender.Send(command);
    }
}
