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


        [HttpGet]
        [Route("getState/{Id}")]
        public async Task<ActionResult<StateInfoDto>> GetState(int Id)
        {
            try
            {
                var data = await this.sateInfoRepository.GetState(Id);

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
        [Route("addState")]
        public async Task<ActionResult<StateInfoDto>> AddState(StateInfoDto stateInfo)
        {
            try
            {
                StateInfoDto objState = await this.sateInfoRepository.AddState(stateInfo);
                if (objState == null)
                    return NotFound();
                else
                    return Ok(objState);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Add State");
                //throw;
            }
        }

        [HttpPost]
        [Route("updateState")]
        public async Task<ActionResult<StateInfoDto>> UpdateState(StateInfoDto stateInfo)
        {
            try
            {
                StateInfoDto objState = await this.sateInfoRepository.UpdateState(stateInfo);
                if (objState == null)
                    return NotFound();
                else
                    return Ok(objState);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Add State");
                //throw;
            }
        }


        [HttpPost]
        [Route("deleteState")]
        public async Task<ActionResult<bool>> DeleteState(int Id)
        {
            try
            {
                bool isSuccess = await this.sateInfoRepository.DeleteState(Id);
                if (isSuccess == null)
                    return NotFound();
                else
                    return Ok(isSuccess);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Add State");
                //throw;
            }
        }



    }
}
