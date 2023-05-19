using SalesOrder.Models.Dtos;

namespace SalesOrder.Web.Services.Interface
{
    public interface ISaleOrderService
    {
        Task<IEnumerable<SalesOrderDto>> GetSalesOrders();
        Task<SalesOrderDto> GetSalesOrder(int Id);
        Task<SalesOrderDto> AddSalesOrder(SalesOrderDto salesOrder);
        Task<SalesOrderDto> UpdateSalesOrder(SalesOrderDto salesOrder);
        Task<bool> DeleteSalesOrder(int Id);
    }
}
