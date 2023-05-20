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
