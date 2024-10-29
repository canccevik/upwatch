using System.Net;

namespace UpWatch.Exceptions;

public class UpWatchBaseException : Exception, IStatusCodedException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.InternalServerError;

    protected UpWatchBaseException()
    {
    }

    protected UpWatchBaseException(string message) : base(message)
    {
    }

    protected UpWatchBaseException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    protected UpWatchBaseException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = (int)statusCode;
    }
}
