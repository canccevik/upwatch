using System.Net;

namespace UpWatch.Exceptions.Exceptions;

public class ItemAlreadyExistsException : UpWatchBaseException
{
    public override string Message { get; }
    
    public ItemAlreadyExistsException(string displayName)
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        Message = $"Item \"{displayName}\" already exist.";
    }
}
