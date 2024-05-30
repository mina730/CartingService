using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartingService.Application.Common.Helper;
/// <summary>
/// Valid RFC 5988 relation types
/// </summary>
public sealed class RelationType
{
    /// <summary>
    /// Relation to itself
    /// </summary>
    public const string self = "self";

    /// <summary>
    /// Navigation to the next page
    /// </summary>
    public const string next = "next";

    /// <summary>
    /// Navigation to the previous page
    /// </summary>
    public const string previous = "previous";

    /// <summary>
    /// Navigation to the first page
    /// </summary>
    public const string first = "first";

    /// <summary>
    /// Navigation to the last page
    /// </summary>
    public const string last = "last";
}

public sealed class RensponseTypeFormat
{
    public const string DefaultGet = "application/json";
    public const string DefaultPost = "application/x-www-form-urlencoded";
}

public sealed class HttpActionVerb
{
    public const string GET = "GET";
    public const string POST = "POST";
    public const string PUT = "PUT";
    public const string DELETE = "DELETE";
    public const string PATCH = "PATCH";
}
