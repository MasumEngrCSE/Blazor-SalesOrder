namespace SalesOrder.Api.Entities
{
    public class OrderWindowSubElement
    {
        public int Id { get; set; }
        public int OrderWindowId { get; set; }
        public int SubElementId { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
