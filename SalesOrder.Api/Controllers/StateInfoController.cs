using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrder.Api.Repositories.Interfaces;
using SalesOrder.Models.Dtos;

namespace SalesOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateInfoController : ControllerBase
    {
        private readonly IStateInfoRepository sateInfoRepository;

        public StateInfoController(IStateInfoRepository sateInfoRepository)
        {
            this.sateInfoRepository = sateInfoRepository;
        }

        [HttpGet]
        [Route("getStateInfo")]
        public async Task<ActionResult<IEnumerable<StateInfoDto>>> GetStateInfo()
        {
            try
            {
                var dataList = await this.sateInfoRepository.GetStates();

                if (dataList == null || dataList.Count()==0)
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
    }
}
