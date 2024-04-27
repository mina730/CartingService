using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartingService.Domain.Exceptions;
public class NoCartFoundException : Exception
{
    public NoCartFoundException(string cartId) : base($"No cart found with id:{cartId}")
    {


    }

}
