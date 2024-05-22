using Asp.Versioning;
using CartingService.Application.CartItems.Commands;
using CartingService.Application.CartItems.Commands.AddCartItemCommand;
using CartingService.Application.Carts.Commands.AddCart;
using CartingService.Application.Carts.Queries.GetCartItemsList;
using CartingService.Application.Carts.Queries.GetCartItemsOnlyList;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.Controllers;
[Route("v{version:apiVersion}/Cart")]
[ApiController]
[ApiVersion(2)]
public class CartV2Controller : ControllerBase
{
    readonly ISender _sender;
    readonly CartController v1Controller;
    public CartV2Controller(ISender sender)
    {
        v1Controller=new CartController(sender);
        _sender = sender;
    }
    [HttpGet]
    public Task<CartItemsOnlyDto> Get([FromQuery] GetCartItemsOnlyQuery query)
    {
        return _sender.Send(query);
    }
    [HttpPost]
    public Task<string?> AddCart(AddCartCommand command)
    {
        return v1Controller.AddCart(command);
    }

    [HttpPost]
    [Route("{cartId}/Item")]
    public Task<int> AddItem([FromRoute(Name = "cartId")] string cartId, AddItemToTheCartCommand command)
    {
        return v1Controller.AddItem(cartId, command);
    }
    [HttpDelete]
    [Route("{cartId}/Item/{itemId}")]
    public Task<int> Item([FromRoute(Name = "cartId")] string cartId
        , [FromRoute(Name = "itemId")] int itemId)
    {
        return v1Controller.Item(cartId, itemId);
    }
}
