using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Models.Dtos
{
    public class SalesOrderWindowDto
    {
        public int? Id { get; set; }
        public int? OrderId { get; set; }
        public int? OrderWindowId { get; set; }
        public string WindowTitle { get; set; }
        public int? WindowQty { get; set; }
        public int? TotalSubElement { get; set; }


        public bool? IsBlank { get; set; }
        public bool? IsNew { get; set; }
    }
}
