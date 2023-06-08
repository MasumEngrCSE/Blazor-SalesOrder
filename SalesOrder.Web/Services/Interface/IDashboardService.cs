using SalesOrder.Models.Dtos;

namespace SalesOrder.Web.Services.Interface
{
    public interface IDashboardService
    {
        Task<SOBarChartDataset> GetSOMonthlyBarChart();
    }
}
