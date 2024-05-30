
using CartingService.Application.Common.Models;
using CartingService.Domain.Entities;

namespace CartingService.Application.Carts.Queries.GetCartItemsOnlyList;
public class ItemDto : LinkResourceBase
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? ImageURL { get; init; }
    public string? ImageText { get; init; }
    public float Price { get; init; }
    public int Quantity { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Item, ItemDto>();
        }
    }
}
