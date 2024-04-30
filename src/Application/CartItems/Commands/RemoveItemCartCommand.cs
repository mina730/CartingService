using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartingService.Application.Common.Interfaces;
using CartingService.Domain.Entities;

namespace CartingService.Application.CartItems.Commands;
public record RemoveItemCartCommand(int Id) : IRequest;

public class RemoveItemCartCommandHandler : IRequestHandler<RemoveItemCartCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveItemCartCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveItemCartCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Items
            .FindAsync(request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, entity);

        _context.Items.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

    }
}
