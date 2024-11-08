using System.Net;
using System.Text.Json.Serialization;
using AutoWrapper.Wrappers;
using AutoWrapperBase = AutoWrapper;

namespace UpWatch.Data.AutoWrapper;

public class ApiException : AutoWrapperBase.Wrappers.ApiException
{
    public int? ErrorCode { get; }
    public object CustomError { get; }
    public HttpStatusCode StatusCode { get; }

    [JsonConstructor]
    public ApiException(object customError, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(customError,
        (int)statusCode)
    {
        CustomError = customError;
        StatusCode = statusCode;
    }

    public ApiException(
        IEnumerable<ValidationError> errors,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest
    )
        : base(errors, (int)statusCode)
    {
    }

    public ApiException(
        Exception ex,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError
    )
        : base(ex, (int)statusCode)
    {
    }

    public ApiException(
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError
    )
        : base("Error", (int)statusCode)
    {
    }
}
