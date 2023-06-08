using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Models.Dtos
{
    public class DashboardDto
    {
        public DashboardDto()
        {
            //BarChartDataset=new List<BarChartDataset>();
        }
        //public List<BarChartDataset>? BarChartDataset { get; set; }

    }


    public class SOBarChartDataset
    {
        public List<string> Label { get; set; }
        public List<double> Data { get; set; }
        public List<string> BackgroundColor { get; set; }
        public List<string> BorderColor { get; set; }
        public List<double> BorderWidth { get; set; }

    }

    
}
