using BlazorBootstrap;
using SalesOrder.Models.Dtos;

namespace SalesOrder.Api.Repositories.Interfaces
{
    public interface IDashboardRepository
    {
        Task<SOBarChartDataset> GetSOMonthlyBarChart();
    }
}
