using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrder.Api.Repositories.Interfaces;
using SalesOrder.Models.Dtos;

namespace SalesOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        public readonly IDashboardRepository dashboardRepository;
        public DashboardController(IDashboardRepository dashboardRepository)
        {
            this.dashboardRepository = dashboardRepository;
        }

        [HttpGet]
        [Route("getSOMonthlyBarChart")]
        public async Task<ActionResult<SOBarChartDataset>> GetSOMonthlyBarChart()
        {
            try
            {
                var dataList = await this.dashboardRepository.GetSOMonthlyBarChart();

                if (dataList == null)
                    return NotFound();
                else
                    return Ok(dataList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrive data");
                //throw;
            }
        }



    }
}
