using SalesOrder.Api.Repositories.Interfaces;
using SalesOrder.Models.Dtos;

namespace SalesOrder.Api.Repositories.Implementations
{
    public class SaleOrderRepository : ISaleOrderRepository
    {
        public async Task<SalesOrderDto> AddSalesOrder(SalesOrderDto salesOrder)
        {
            try
            {

                return salesOrder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //throw new NotImplementedException();
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

        public Task<SalesOrderDto> UpdateSalesOrder(SalesOrderDto salesOrder)
        {
            throw new NotImplementedException();
        }
    }
}
