using Microsoft.AspNetCore.Components;
using PlannerApp.Shared.Models;

namespace PlannerApp.Components;

public partial class PlansCardsList
{
    private bool _isBusy { get; set; }
    private int _pageNumber = 1;
    private int _pageSize = 10;
    private string _query = string.Empty;
    
    [Parameter]
    public Func<string, int, int, Task<PagedList<PlanSummary>>> FetchPlans { get; set; }
    
    private PagedList<PlanSummary> _result = new();
    
    protected async override Task OnInitializedAsync()
    {
        await GetPlansAsync();
    }

    private async Task GetPlansAsync(int pageNumber = 1)
    {
        _pageNumber = pageNumber;
        _isBusy = true;
        _result = await FetchPlans?.Invoke(_query, _pageNumber, _pageSize); 
        _isBusy = false;
    }
}