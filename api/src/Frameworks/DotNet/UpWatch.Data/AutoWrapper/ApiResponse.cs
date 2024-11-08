using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using UpWatch.Data.Pagination;

namespace UpWatch.Data.AutoWrapper;

public class ApiResponse<T>
{
    public ApiResponse()
    {
        StatusCode = HttpStatusCode.OK;
        Message = string.Empty;
        Payload = default;
    }

    [JsonConstructor]
    public ApiResponse(
        string message = "",
        T? payload = default,
        HttpStatusCode statusCode = HttpStatusCode.OK
    )
    {
        StatusCode = statusCode;
        Message = message == string.Empty ? "Success" : message;
        Payload = payload;
    }

    public ApiResponse(T payload, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        StatusCode = statusCode;
        Message = "Success";
        Payload = payload;
    }

    public ApiResponse(JArray payload, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        StatusCode = statusCode;
        Message = "Success";
        Payload = payload.ToObject<T>();
    }

    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public T? Payload { get; set; }
}

public class ApiResponse
{
    public ApiResponse() { }

    [JsonConstructor]
    public ApiResponse(
        string message = "",
        object? payload = default,
        HttpStatusCode statusCode = HttpStatusCode.OK
    )
    {
        StatusCode = statusCode;
        Message = message == string.Empty ? "Success" : message;
        Payload = payload;
    }

    public ApiResponse(object payload, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        StatusCode = statusCode;
        Message = "Success";
        Payload = payload;
    }

    public ApiResponse(HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        StatusCode = statusCode;
        Message = "Success";
        Payload = default;
    }

    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public object? Payload { get; set; }
}

public class PagedApiResponse<T>
{
    public PagedApiResponse()
    {
        Payload = new List<T>();
    }

    [JsonConstructor]
    public PagedApiResponse(
        PagedResult<T> pagedResult,
        HttpStatusCode statusCode = HttpStatusCode.OK
    )
    {
        StatusCode = statusCode;
        Message = "Success";
        Payload = pagedResult.Items.ToList();
        Pagination = CreatePaginationFromPagedResult(pagedResult);
    }

    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public PaginationFilter Pagination { get; set; }
    public List<T> Payload { get; set; }

    private PaginationFilter CreatePaginationFromPagedResult(PagedResult<T> pagedResult)
    {
        return new PaginationFilter
        {
            Limit = pagedResult.Limit,
            Page = pagedResult.Page,
            HasNextPage = pagedResult.HasNextPage
        };
    }
}
