using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartingService.Application.Common.Interfaces;
using CartingService.Application.Common.Mappings;
using CartingService.Application.Common.Models;

namespace CartingService.Application.Carts.Queries.GetCartItemsList;
public record GetCartItemsQuery : IRequest<CartDto>
{
    public string? CartId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

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
        Guard.Against.NullOrEmpty(request.CartId);

        var cart = await _context.Carts
            .FirstOrDefaultAsync(x => x.CartId == request.CartId);
        Guard.Against.NotFound(request.CartId, cart);

        var items = await _context.Items.Where(item => item.CartId == cart!.CartId)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        Console.WriteLine($"item count:{items.Items.Count}");
        if (items != null && items.Items.Count > 0)
        {
            foreach ( var item in items.Items )
            {
                cart.ItemList.Add(item);
            }
        }

        var cartDto = _mapper.Map<CartDto>(cart);
        Console.WriteLine($"Cart item count:{cartDto.ItemList.Count}");
        return cartDto;
    }
}

