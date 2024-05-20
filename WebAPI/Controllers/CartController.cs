using CartingService.Application.Carts.Queries.GetCartItemsList;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    readonly ISender _sender;
    public CartController(ISender sender) {
        _sender = sender;
    }
    [HttpGet]
    public Task<CartDto> Get([FromQuery] GetCartItemsQuery query)
    {
        return _sender.Send(query);
    }
    //public Task<string?> AddCart(ISender sender, AddCartCommand command)
    //{
    //    return sender.Send(command);
    //}
}
