using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Utils.Library.Exceptions;

namespace RAS.Core.Exceptions;

[UtilsException(StatusCodes.Status404NotFound, "ERROR_MENU_ITEM_NOT_FOUND")]
public class MenuItemNotFoundException : Exception
{
    public MenuItemNotFoundException()
    {
    }

    public MenuItemNotFoundException(string message) : base(message)
    {
    }

    public MenuItemNotFoundException(Guid id) : base($"Menu item {id} not found.")
    {
    }

    public MenuItemNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected MenuItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
