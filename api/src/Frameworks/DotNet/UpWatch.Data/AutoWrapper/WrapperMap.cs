using System.Net;
using AutoWrapper;

namespace UpWatch.Data.AutoWrapper;

public class WrapperMap
{
    [AutoWrapperPropertyMap(Prop.ResponseException)]
    public required object Error { get; set; }

    [AutoWrapperPropertyMap(Prop.ResponseException_ExceptionMessage)]
    public required object Message { get; set; }

    [AutoWrapperPropertyMap(Prop.StatusCode)]
    public required HttpStatusCode StatusCode { get; set; }
}
