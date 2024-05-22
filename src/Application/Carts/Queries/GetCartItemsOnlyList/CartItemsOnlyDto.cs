
using CartingService.Domain.Entities;

namespace CartingService.Application.Carts.Queries.GetCartItemsOnlyList;
public class CartItemsOnlyDto
{
    public CartItemsOnlyDto()
    {
        ItemList = Array.Empty<ItemDto>();
    }
    public IReadOnlyCollection<ItemDto> ItemList { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Cart, CartItemsOnlyDto>();
        }
    }
}
