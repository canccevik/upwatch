using System.Net;

namespace UpWatch.Exceptions.Exceptions;

public class ItemNotFoundException : UpWatchBaseException
{
    public override string Message { get; }

    public ItemNotFoundException(object displayName)
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        Message = $"Item \"{displayName}\" not found!";
    }

    public ItemNotFoundException(string message)
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        Message = message;
    }
}
