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

        var cartDto = _mapper.Map<CartDto>(cart);
        return cartDto;
    }
}

