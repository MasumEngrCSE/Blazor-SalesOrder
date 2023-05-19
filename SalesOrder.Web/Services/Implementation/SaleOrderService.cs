using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Interface;
using System.Collections.Generic;

namespace SalesOrder.Web.Services.Implementation
{
    public class SaleOrderService : ISaleOrderService
    {
        public async Task<SalesOrderDto> AddSalesOrder(SalesOrderDto salesOrder)
        {
            try
            {
                //var ret = new SalesOrderDto();

                return salesOrder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //throw new NotImplementedException();
        }

        public async Task<bool> DeleteSalesOrder(int Id)
        {
            try
            {
                return  true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<SalesOrderDto> GetSalesOrder(int Id)
        {
            try
            {
                var ret = new SalesOrderDto();
                ret.Id = Id;


                return ret;
            }
            catch (Exception wx)
            {

                throw wx;
            }
        }

        public async Task<IEnumerable<SalesOrderDto>> GetSalesOrders()
        {
            try
            {
                var dataList =new List<SalesOrderDto>();


                return dataList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //throw new NotImplementedException();
        }

        public async Task<SalesOrderDto> UpdateSalesOrder(SalesOrderDto salesOrder)
        {
            try
            {
                //var ret = new SalesOrderDto();

                return salesOrder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
