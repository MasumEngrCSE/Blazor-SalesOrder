using SalesOrder.Api.Data;
using SalesOrder.Api.Entities;
using SalesOrder.Api.Repositories.Interfaces;
using SalesOrder.Models.Dtos;

namespace SalesOrder.Api.Repositories.Implementations
{
    public class SaleOrderRepository : ISaleOrderRepository
    {
        private readonly SalesOrderDBContext _DBContext;
        public SaleOrderRepository(SalesOrderDBContext salesOrderDBContext)
        {
            _DBContext = salesOrderDBContext;
        }

        public async Task<SalesOrderDto> AddSalesOrder(SalesOrderDto salesOrder)
        {
            try
            {

                #region OrderMaster
                var obj = new OrderMaster();
                obj.OrderTitle = salesOrder.OrderTitle;
                obj.OrderDate = salesOrder.OrderDate;
                obj.StateId = salesOrder.StateId;
                obj.Remarks = salesOrder.Remarks;
                obj.CreatedDate = DateTime.Now;
                obj.CreatedBy = salesOrder.CreatedBy;

                this._DBContext.orderMasters.AddAsync(obj);
                this._DBContext.SaveChangesAsync();

                salesOrder.Id = obj.Id;
                salesOrder.CreatedDate = obj.CreatedDate;
                #endregion


                #region OrderWindow
                foreach (var item in salesOrder.SalesOrderWindowList)
                {
                    var objSW = new OrderWindow();
                    objSW.OrderId = salesOrder.Id;
                    objSW.WindowTitle = salesOrder.WindowTitle;
                    objSW.Qty = salesOrder.WindowQty;
                    objSW.TotalSubElement = salesOrder.TotalSubElement;
                    objSW.CreatedDate = DateTime.Now;
                    objSW.CreatedBy = salesOrder.CreatedBy;

                    this._DBContext.orderWindows.AddAsync(objSW);
                    this._DBContext.SaveChangesAsync();

                    item.Id = objSW.Id;

                }

                #endregion



                #region MyRegion
                foreach (var item in salesOrder.WindowSubElementList)
                {
                    var objSE = new OrderWindowSubElement();
                    objSE.OrderWindowId = salesOrder.SalesOrderWindowList.FirstOrDefault(p=>p.OrderWindowId==item.OrderWindowId).Id;
                    objSE.SubElement = item.SubElement;
                    objSE.SubElementType = item.SubElementType;
                    objSE.Width = item.SubElementWidth;
                    objSE.Height = item.SubElementHeight;

                    objSE.CreatedDate = DateTime.Now;
                    objSE.CreatedBy = salesOrder.CreatedBy;

                    this._DBContext.orderWindowsSubElements.AddAsync(objSE);
                    this._DBContext.SaveChangesAsync();
                }

                #endregion



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
