using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartingService.Application.Common.Interfaces;
using CartingService.Domain.Entities;
using CartingService.Domain.Events;

namespace CartingService.Application.CartItems.Commands;
public record AddItemToTheCartCommand : IRequest<int>
{
    public string? CartId { get; init; }

    public string? Name { get; init; }
    public string? ImageURL { get; init; }
    public string? ImageText { get; init; }
    public float Price { get; init; }
    public int Quantity { get; init; }
}

class AddItemToTheCartCommandHandler : IRequestHandler<AddItemToTheCartCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AddItemToTheCartCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddItemToTheCartCommand request, CancellationToken cancellationToken)
    {
        var entity = new Item
        {
            CartId=request.CartId,
            Name=request.Name,
            ImageURL=request.ImageURL,
            ImageText=request.ImageText,
            Price=request.Price,
            Quantity=request.Quantity,  
        };

        _context.Items.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
