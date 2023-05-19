﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Models.Dtos
{
    public class SalesOrderDto
    {
        public int Id { get; set; }
        public string CustomCode { get; set; }
        public string OrderTitle { get; set; }

        public DateTime OrderDate { get; set; }
        public int? StateId { get; set; }
        public string? StateName { get; set; }
        public string WindowTitle { get; set; }
        public int WindowQty { get; set; }
        public int TotalSubElement { get; set; }
        public int SubElement { get; set; }
        public string SubElementType { get; set; }
        public int SubElementWidth { get; set; }
        public int SubElementHeight { get; set; }

        public string Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsBlank { get; set; }

        public List<SalesOrderDto> SalesOrderWindowList { get; set; }
        public List<SalesOrderDto> WindowSubElementList { get; set; }

    }
}
