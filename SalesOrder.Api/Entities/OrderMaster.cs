namespace SalesOrder.Api.Entities
{
    public class OrderMaster
    {
        public int Id { get; set; }
        public string CustomCode { get; set; }
        public string OrderTitle { get; set; }
        public DateTime OrderDate { get; set; }
        public int StateId { get; set; }
        public string Remarks { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
