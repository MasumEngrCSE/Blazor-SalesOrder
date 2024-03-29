﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Models.Dtos
{
    public class SalesOrderDto
    {
        public int Id { get; set; }
        public string? CustomCode { get; set; }


        [Required(ErrorMessage = "Please provide Value")]
        public string OrderTitle { get; set; }

        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "Please provide State")]
        public int? StateId { get; set; }
        public string? StateName { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsBlank { get; set; }

        public List<SalesOrderWindowDto>? SalesOrderWindowList { get; set; } = default;
        public List<SalesOrderWindowDto>? SalesOrderWindowDeleteList { get; set; } = default;

        public List<WindowSubElementDto>? WindowSubElementList { get; set; }= default;
        public List<WindowSubElementDto>? WindowSubElementDeleteList { get; set; }= default;
        

    }
}
