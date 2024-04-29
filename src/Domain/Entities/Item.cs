using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CartingService.Domain.Entities;
public class Item : BaseAuditableEntity
{
    public string? CartId { get; set; }
    public string? Name { get; set; }
    public string? ImageURL { get; set; }
    public string? ImageText { get; set; }
    public float Price { get; set; }
    public int Quantity {  get; set; }

}
