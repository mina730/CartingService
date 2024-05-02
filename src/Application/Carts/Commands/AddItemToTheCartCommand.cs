using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartingService.Application.Common.Interfaces;
using CartingService.Domain.Entities;

namespace CartingService.Application.CartItems.Commands;
public record AddCartCommand : IRequest<string?>
{
    public string? CartId { get; init; }
}

class AddCartCommandHandler : IRequestHandler<AddCartCommand, string?>
{
    private readonly IApplicationDbContext _context;

    public AddCartCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string?> Handle(AddCartCommand request, CancellationToken cancellationToken)
    {
        var entity = new Cart
        {
            CartId=request.CartId
        };

        _context.Carts.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.CartId;
    }
}
