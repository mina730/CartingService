using Asp.Versioning;
using CartingService.Application.CartItems.Commands;
using CartingService.Application.CartItems.Commands.AddCartItemCommand;
using CartingService.Application.Carts.Commands.AddCart;
using CartingService.Application.Carts.Queries.GetCartItemsList;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiVersion(1)]
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    readonly ISender _sender;
    public CartController(ISender sender)
    {
        _sender = sender;
    }
    /// <summary>
    /// Get Cart Model and its Items list
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<CartDto> Get([FromQuery] GetCartItemsQuery query)
    {
        return _sender.Send(query);
    }

    /// <summary>
    /// Add a new cart
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<string?> AddCart(AddCartCommand command)
    {
        return _sender.Send(command);
    }
    /// <summary>
    /// Add an Item in a specific cart
    /// </summary>
    /// <param name="cartId"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("{cartId}/Item")]
    public Task<int> AddItem([FromRoute(Name = "cartId")] string cartId, AddItemToTheCartCommand command)
    {
        command.CartId = cartId;//ignore what in the object and add the item into cartId in the QueryString
        return _sender.Send(command);
    }
    /// <summary>
    /// Delete an a item from a specific cart
    /// </summary>
    /// <param name="cartId"></param>
    /// <param name="itemId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{cartId}/Item/{itemId}")]
    public Task<int> Item([FromRoute(Name = "cartId")] string cartId
        , [FromRoute(Name = "itemId")] int itemId)
    {
        var id = _sender.Send(new RemoveItemCartCommand() { CartId = cartId, ItemId = itemId });
        return id;
    }
}
