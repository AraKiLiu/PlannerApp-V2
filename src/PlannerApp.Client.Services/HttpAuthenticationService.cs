using System.Net.Http.Json;
using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;

namespace PlannerApp.Client.Services;

public class HttpAuthenticationService : IAuthenticationService
{

    private readonly HttpClient _client;

    public HttpAuthenticationService(HttpClient client)
    {
        _client = client; 
    }

    public async Task<ApiResponse> RegisterUserAsync(RegisterRequest model)
    {
        var response = await _client.PostAsJsonAsync("/api/v2/auth/register", model); 
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
            return result; 
        }
        else
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
            throw new ApiException(errorResponse, response.StatusCode); 
        }
    }
}