using System.Net;
using PlannerApp.Shared.Responses;

namespace PlannerApp.Client.Services.Exceptions;

public class ApiException : Exception
{
    public ApiErrorResponse ApiErrorResponse { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public ApiException(ApiErrorResponse error, HttpStatusCode statusCode) : this(error)
    {
        StatusCode = statusCode; 
    }

    public ApiException(ApiErrorResponse error)
    {
        ApiErrorResponse = error;
    }
}