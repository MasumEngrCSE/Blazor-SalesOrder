using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Interface;
using System.Net.Http.Json;

namespace SalesOrder.Web.Services.Implementation
{
    public class DashboardService : IDashboardService
    {

        private readonly HttpClient httpClient;
        public DashboardService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<SOBarChartDataset> GetSOMonthlyBarChart()
        {
            try
            {
                var barChartdata = await this.httpClient.GetFromJsonAsync<SOBarChartDataset>($"api/Dashboard/getSOMonthlyBarChart");

                return barChartdata;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
