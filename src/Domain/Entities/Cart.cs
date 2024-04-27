using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartingService.Domain.Entities;
public class Cart
{
    public string? CartId { get; set; }
    public IList<Item> ItemList { get; private set; } = new List<Item>();
}
