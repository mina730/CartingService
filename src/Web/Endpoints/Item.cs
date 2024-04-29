using CartingService.Application.CartItems.Commands;
using CartingService.Application.TodoItems.Commands.CreateTodoItem;

namespace CartingService.Web.Endpoints;

public class Items : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(AddNewItem);
    }

    public Task<int> AddNewItem(ISender sender, AddItemToTheCartCommand command)
    {
        return sender.Send(command);
    }

}
