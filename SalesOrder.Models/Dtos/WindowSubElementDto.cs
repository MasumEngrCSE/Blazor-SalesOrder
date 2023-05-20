using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Models.Dtos
{
    public class WindowSubElementDto
    {
        public int? Id { get; set; }
        public int? OrderId { get; set; }
        public int? OrderWindowId { get; set; }
        public int? SubElement { get; set; }
        public string SubElementType { get; set; }
        public int? SubElementWidth { get; set; }
        public int? SubElementHeight { get; set; }
        public bool? IsBlank { get; set; }
    }
}
