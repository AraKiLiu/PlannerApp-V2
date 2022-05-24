using System.Net.Http.Json;
using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;

namespace PlannerApp.Client.Services;

public class HttpPlansService:IPlansService
{
    public readonly HttpClient _httpClient;
    
    public HttpPlansService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ApiResponse<PagedList<PlanSummary>>> GetPlansAsync(string query = null, int pageNumber = 1, int pageSize = 10)
    {
        var response =await _httpClient.GetAsync($"/api/v2/plans?query={query}&pageNumber={pageNumber}&pageSize={pageSize}");
        if (response.IsSuccessStatusCode)   //200
        {
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<PagedList<PlanSummary>>>();
            return result;
        }
        else
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
            throw new ApiException(errorResponse, response.StatusCode);
        }
    }
}