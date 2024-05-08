using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartingService.Application.Common.Interfaces;
using CartingService.Application.Common.Models;

namespace CartingService.Application.Carts.Queries.GetCartItemsList;
public record GetCartItemsQuery : IRequest<CartDto>
{
    public string? CartId { get; init; }

}
public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, CartDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCartItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CartDto> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
    {
        var cartDto = await _context.Carts.Include(c => c.ItemList)
            .FirstOrDefaultAsync(x => x.CartId == request.CartId);

        var cart = _mapper.Map<CartDto>(cartDto);
        return cart;
    }
}

