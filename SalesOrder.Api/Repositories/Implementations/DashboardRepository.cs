using BlazorBootstrap;
using SalesOrder.Api.Data;
using SalesOrder.Api.Repositories.Interfaces;
using SalesOrder.Models.Dtos;

namespace SalesOrder.Api.Repositories.Implementations
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly SalesOrderDBContext _DBContext;

        public DashboardRepository(SalesOrderDBContext salesOrderDBContext)
        {
            _DBContext = salesOrderDBContext;
        }

        public async Task<SOBarChartDataset> GetSOMonthlyBarChart()
        {
            try
            {
                SOBarChartDataset barChartdata = new SOBarChartDataset();

                barChartdata.Label = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };

                barChartdata.Data = new List<double> { 50, 60, 30, 70, 40, 70 };


                return barChartdata;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
