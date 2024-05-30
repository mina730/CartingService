using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartingService.Application.Common.Models;
public class Link
{
    public string? Href { get; set; }
    public string? Rel { get; set; }
    public string? Method { get; set; }
    public string? Type { get; set; }

    public Link()
    {

    }

    public Link(string href, string rel, string method, string? type)
    {
        Href = href;
        Rel = rel;
        Method = method;
        Type = type;
    }
}
