using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartingService.Domain.Entities;

namespace CartingService.Application.Carts.Queries.GetCartItemsList;
public class CartDto
{
    public CartDto()
    {
        ItemList = Array.Empty<ItemDto>();
    }
    public string? CartId { get; set; }
    public IReadOnlyCollection<ItemDto> ItemList { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Cart, CartDto>();
        }
    }
}
