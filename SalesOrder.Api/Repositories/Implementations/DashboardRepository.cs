using BlazorBootstrap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SalesOrder.Api.Data;
using SalesOrder.Api.Repositories.Interfaces;
using SalesOrder.Models.Dtos;
using System.Security.Cryptography.X509Certificates;

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

                DateTime fdate = DateTime.Now.AddMonths(-12);
                var today = DateTime.Now;

                SOBarChartDataset barChartdata = new SOBarChartDataset();

                var data = await ((from p in this._DBContext.orderMasters
                                   join s in this._DBContext.stateInfo on p.StateId equals s.Id

                                   where p.OrderDate >= fdate && p.OrderDate <= today
                                   select new SalesOrderDto
                                   {
                                       Id = p.Id,
                                       OrderTitle = p.OrderTitle,
                                       OrderDate = p.OrderDate,
                                       StateId = p.StateId,
                                       StateName = s.Name,
                                   }
                                  ).GroupBy(p => new { p.StateId,p.StateName })
                                  .Select(group => new
                                  {
                                      StateId = group.Key.StateId,
                                      StateName= group.Key.StateName,
                                      TotalCount = group.Count()
                                  }
                                  )

                                  ).ToListAsync();


                List<string> lavelLst=new List<string>();
                List<double> dataLst = new List<double>();
                foreach (var itm in data)
                {
                    lavelLst.Add(itm.StateName);
                    dataLst.Add(itm.TotalCount);
                }
                barChartdata.Label= lavelLst;
                barChartdata.Data = dataLst;

                //barChartdata.Label = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };

                //barChartdata.Data = new List<double> { 50, 60, 30, 70, 40, 70 };


                return barChartdata;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
