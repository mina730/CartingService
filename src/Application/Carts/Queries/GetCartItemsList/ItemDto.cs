using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using CartingService.Domain.Entities;

namespace CartingService.Application.Carts.Queries.GetCartItemsList;
public class ItemDto
{
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
