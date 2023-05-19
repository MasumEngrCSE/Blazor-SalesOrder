using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Services.Implementation
{
    public class SaleOrderService : ISaleOrderService
    {
        public Task<SalesOrderDto> AddSalesOrder(SalesOrderDto stateInfo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSalesOrder(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<SalesOrderDto> GetSalesOrder(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SalesOrderDto>> GetSalesOrders()
        {
            throw new NotImplementedException();
        }

        public Task<SalesOrderDto> UpdateSalesOrder(SalesOrderDto stateInfo)
        {
            throw new NotImplementedException();
        }
    }
}
