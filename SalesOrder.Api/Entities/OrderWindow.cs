using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesOrder.Api.Entities
{
    public class OrderWindow
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int WindowId { get; set; }
        public int Qty { get; set; }
        public int TotalSubElement { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }

        [ForeignKey("OrderId")]
        public OrderMaster OrderMaster { get; set; }

        [ForeignKey("WindowId")]
        public Window Window { get; set; }
    }
}
