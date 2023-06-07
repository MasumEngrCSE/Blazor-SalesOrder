using SalesOrder.Models.Dtos;

namespace SalesOrder.Api.Repositories.Interfaces
{
    public interface ISaleOrderRepository
    {
        Task<IEnumerable<SalesOrderDto>> GetSalesOrders();
        Task<SalesOrderDto> GetSalesOrder(int Id);
        SalesOrderDto AddSalesOrder(SalesOrderDto salesOrder);
        SalesOrderDto UpdateSalesOrder(SalesOrderDto salesOrder);
        Task<bool> DeleteSalesOrder(int Id);
        Task<IEnumerable<SalesOrderDto>> getSalesOrderSateWiseMonthlyBarChart();
    }
}
