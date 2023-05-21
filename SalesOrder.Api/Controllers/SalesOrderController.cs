using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrder.Api.Repositories.Interfaces;
using SalesOrder.Models.Dtos;

namespace SalesOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        public readonly ISaleOrderRepository saleOrderRepository;
        public SalesOrderController(ISaleOrderRepository saleOrderRepository)
        {
            this.saleOrderRepository = saleOrderRepository;
        }


        [HttpGet]
        [Route("getSalesOrders")]
        public async Task<ActionResult<IEnumerable<SalesOrderDto>>> GetSalesOrders()
        {
            try
            {
                var dataList = await this.saleOrderRepository.GetSalesOrders();

                if (dataList == null || dataList.Count() == 0)
                    return NotFound();
                else
                    return Ok(dataList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrive data");
                //throw;
            }
        }


        [HttpGet]
        [Route("getSalesOrder/{Id}")]
        public async Task<ActionResult<SalesOrderDto>> GetSalesOrder(int Id)
        {
            try
            {
                var data = await this.saleOrderRepository.GetSalesOrder(Id);

                if (data == null)
                    return NotFound();
                else
                    return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrive data");
                //throw;
            }
        }




        [HttpPost]
        [Route("addSalesOrder")]
        public async Task<ActionResult<SalesOrderDto>> AddSalesOrder(SalesOrderDto salesOrder)
        {
            try
            {
                SalesOrderDto objSalesOrder =  this.saleOrderRepository.AddSalesOrder(salesOrder);
                //SalesOrderDto objSalesOrder = await this.saleOrderRepository.AddSalesOrder(salesOrder);
                if (objSalesOrder == null)
                    return NotFound();
                else
                    return Ok(objSalesOrder);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Add Sales Order");
            }
        }



    }
}
