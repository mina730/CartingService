using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartingService.Application.Common.Interfaces;
using CartingService.Application.Common.Models;

namespace CartingService.Application.Carts.Queries.GetCartItemsOnlyList;
public record GetCartItemsOnlyQuery : IRequest<CartItemsOnlyDto>
{
    public string? CartId { get; init; }

}
public class GetCartItemsOnlyQueryHandler : IRequestHandler<GetCartItemsOnlyQuery, CartItemsOnlyDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCartItemsOnlyQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CartItemsOnlyDto> Handle(GetCartItemsOnlyQuery request, CancellationToken cancellationToken)
    {
        //if (String.IsNullOrEmpty(request.CartId))
        //{
        //    throw new ArgumentNullException(request.CartId, "CartId cannot be empty");
        //}
        Guard.Against.NullOrEmpty(request.CartId);

        var cart = await _context.Carts.Include(c => c.ItemList)
            .FirstOrDefaultAsync(x => x.CartId == request.CartId);

        Guard.Against.NotFound(request.CartId, cart);

        //if (cartDto == null)
        //{
        //    throw new NotFoundException(request.CartId??"", "Cart");
        //}

        var cartDto = _mapper.Map<CartItemsOnlyDto>(cart);
        return cartDto;
    }
}

