using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartingService.Application.Common.Interfaces;
using CartingService.Domain.Entities;
using MediatR;

namespace CartingService.Application.CartItems.Commands;
public record RemoveItemCartCommand : IRequest<int>
{
    public int ItemId;
    public string? CartId;
}

public class RemoveItemCartCommandHandler : IRequestHandler<RemoveItemCartCommand, int>
{
    private readonly IApplicationDbContext _context;

    public RemoveItemCartCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(RemoveItemCartCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Items
            .FirstOrDefaultAsync(x => x.Id == request.ItemId && x.CartId == request.CartId);
        Guard.Against.NotFound(request.ItemId, entity);

        _context.Items.Remove(entity);

        return await _context.SaveChangesAsync(cancellationToken);
    }
}
