using Microsoft.EntityFrameworkCore;
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

        public SalesOrderDto AddSalesOrder(SalesOrderDto salesOrder)
        {
            try
            {

                #region OrderMaster
                var obj = new OrderMaster();
                obj.CustomCode = salesOrder.CustomCode ?? "";
                obj.OrderTitle = salesOrder.OrderTitle;
                obj.OrderDate = salesOrder.OrderDate ?? DateTime.Now;
                obj.StateId = salesOrder.StateId;
                obj.Remarks = salesOrder.Remarks ?? "";
                obj.CreatedDate = DateTime.Now;
                obj.CreatedBy = salesOrder.CreatedBy;

                this._DBContext.orderMasters.Add(obj);
                this._DBContext.SaveChanges();

                salesOrder.Id = obj.Id;
                salesOrder.CreatedDate = obj.CreatedDate;
                #endregion


                #region OrderWindow
                foreach (var item in salesOrder.SalesOrderWindowList)
                {
                    var objSW = new OrderWindow();
                    objSW.OrderId = salesOrder.Id;
                    objSW.WindowTitle = item.WindowTitle;
                    objSW.Qty = item.WindowQty ?? 0;
                    objSW.TotalSubElement = item.TotalSubElement ?? 0;
                    objSW.CreatedDate = DateTime.Now;
                    objSW.CreatedBy = salesOrder.CreatedBy;

                    this._DBContext.orderWindows.Add(objSW);
                    this._DBContext.SaveChanges();

                    item.Id = objSW.Id;

                }

                #endregion



                #region MyRegion
                foreach (var item in salesOrder.WindowSubElementList)
                {
                    var objSE = new OrderWindowSubElement();
                    objSE.OrderWindowId = salesOrder.SalesOrderWindowList.FirstOrDefault(p => p.OrderWindowId == item.OrderWindowId).Id ?? 0;
                    objSE.SubElement = item.SubElement ?? 0;
                    objSE.SubElementType = item.SubElementType;
                    objSE.Width = item.SubElementWidth ?? 0;
                    objSE.Height = item.SubElementHeight ?? 0;

                    objSE.CreatedDate = DateTime.Now;
                    objSE.CreatedBy = salesOrder.CreatedBy;

                    this._DBContext.orderWindowsSubElements.Add(objSE);
                    this._DBContext.SaveChanges();
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

        public async Task<SalesOrderDto> GetSalesOrder(int Id)
        {
            try
            {

                var data = await (from p in this._DBContext.orderMasters.Where(p => p.Id == Id)
                                  select new SalesOrderDto
                                  {
                                      Id = p.Id,
                                      OrderTitle = p.OrderTitle,
                                      OrderDate = p.OrderDate,
                                      StateId = p.StateId,
                                      StateName = p.StateInfo.Name,
                                      Remarks = p.Remarks,
                                      CreatedBy = p.CreatedBy,
                                      CreatedDate = p.CreatedDate,
                                      UpdatedBy = p.UpdatedBy,
                                      UpdatedDate = p.UpdatedDate,
                                      // SalesOrderWindowList=p.
                                  }).FirstOrDefaultAsync();


                data.SalesOrderWindowList = await (from p in this._DBContext.orderWindows.Where(p => p.OrderId == Id)
                                                   select new SalesOrderWindowDto
                                                   {
                                                       Id = p.Id,
                                                       OrderId = p.OrderId,
                                                       WindowTitle = p.WindowTitle,
                                                       WindowQty = p.Qty,
                                                       TotalSubElement = p.TotalSubElement,
                                                   }).ToListAsync();


                data.WindowSubElementList = await (from p in this._DBContext.orderWindows.Where(p => p.OrderId == Id)
                                                   join s in this._DBContext.orderWindowsSubElements on p.Id equals s.OrderWindowId
                                                   select new WindowSubElementDto
                                                   {
                                                       Id = s.Id,
                                                       OrderId = p.OrderId,
                                                       OrderWindowId = s.OrderWindowId,
                                                       WindowTitle=p.WindowTitle,
                                                       SubElement = s.SubElement,
                                                       SubElementType = s.SubElementType,
                                                       SubElementWidth = s.Width,
                                                       SubElementHeight = s.Height,
                                                   }).ToListAsync();


                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<SalesOrderDto>> GetSalesOrders()
        {
            try
            {
                var data = await (from p in this._DBContext.orderMasters
                                  join s in this._DBContext.stateInfo on p.StateId equals s.Id
                                  select new SalesOrderDto
                                  {
                                      Id = p.Id,
                                      OrderTitle = p.OrderTitle,
                                      OrderDate = p.OrderDate,
                                      StateId = p.StateId,
                                      StateName = s.Name,
                                      Remarks = p.Remarks,
                                      CreatedBy = p.CreatedBy,
                                      CreatedDate = p.CreatedDate,
                                      UpdatedBy = p.UpdatedBy,
                                      UpdatedDate = p.UpdatedDate,
                                  }).ToListAsync();


                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SalesOrderDto UpdateSalesOrder(SalesOrderDto salesOrder)
        {
            try
            {

                #region OrderMaster
                var obj = this._DBContext.orderMasters.FirstOrDefault(p=>p.Id==salesOrder.Id);
                obj.CustomCode = salesOrder.CustomCode ?? "";
                obj.OrderTitle = salesOrder.OrderTitle;
                obj.OrderDate = salesOrder.OrderDate ?? DateTime.Now;
                obj.StateId = salesOrder.StateId;
                obj.Remarks = salesOrder.Remarks ?? "";
                obj.UpdatedDate = DateTime.Now;
                obj.UpdatedBy = salesOrder.UpdatedBy;

                //this._DBContext.orderMasters.Add(obj);
                this._DBContext.SaveChanges();
                #endregion


                #region OrderWindow
                foreach (var item in salesOrder.SalesOrderWindowList)
                {
                    
                   // var objSW = new OrderWindow();
                    var objSW = this._DBContext.orderWindows.FirstOrDefault(p => p.Id == item.Id);
                    if (objSW == null)
                    {
                        objSW = new OrderWindow();
                        objSW.CreatedDate = DateTime.Now;
                        objSW.CreatedBy = salesOrder.CreatedBy;

                        this._DBContext.orderWindows.Add(objSW);
                    }
                    else
                    {
                        objSW.UpdatedDate = DateTime.Now;
                        objSW.UpdatedBy = salesOrder.UpdatedBy;
                    }
                    objSW.OrderId = salesOrder.Id;
                    objSW.WindowTitle = item.WindowTitle;
                    objSW.Qty = item.WindowQty ?? 0;
                    objSW.TotalSubElement = item.TotalSubElement ?? 0;

                    this._DBContext.SaveChanges();

                    item.Id = objSW.Id;

                }

                #endregion



                #region MyRegion
                foreach (var item in salesOrder.WindowSubElementList)
                {
                    //var objSE = new OrderWindowSubElement();
                    var objSE = this._DBContext.orderWindowsSubElements.FirstOrDefault(p => p.Id == item.Id);
                    if (objSE == null)
                    {
                        objSE = new OrderWindowSubElement();
                        objSE.OrderWindowId = salesOrder.SalesOrderWindowList.FirstOrDefault(p => p.OrderWindowId == item.OrderWindowId).Id ?? 0;
                        objSE.CreatedDate = DateTime.Now;
                        objSE.CreatedBy = salesOrder.CreatedBy;

                        this._DBContext.orderWindowsSubElements.Add(objSE);
                    }
                    else
                    {
                        objSE.UpdatedDate = DateTime.Now;
                        objSE.UpdatedBy = salesOrder.UpdatedBy;
                    }
                   
                    objSE.SubElement = item.SubElement ?? 0;
                    objSE.SubElementType = item.SubElementType;
                    objSE.Width = item.SubElementWidth ?? 0;
                    objSE.Height = item.SubElementHeight ?? 0;


                    this._DBContext.SaveChanges();
                    item.Id = objSE.Id;
                }

                #endregion



                return salesOrder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
