using Microsoft.AspNetCore.Http;
using System.Runtime.Serialization;
using Utils.Library.Exceptions;

namespace RAS.Core.Exceptions;

[UtilsException(StatusCodes.Status404NotFound, "ERROR_ORDER_NOT_FOUND")]
public class OrderNotFoundException : Exception
{
    public OrderNotFoundException()
    {
    }

    public OrderNotFoundException(string message) : base(message)
    {
    }

    public OrderNotFoundException(Guid id) : base($"Order {id} not found.")
    {
    }

    public OrderNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected OrderNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
