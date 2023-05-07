using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Interface;
using System.Net.Http.Json;

namespace SalesOrder.Web.Services.Implementation
{
    public class StateInfoService: IStateInfoService
    {
        private readonly HttpClient httpClient;

        public StateInfoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<StateInfoDto> AddState(StateInfoDto stateInfo)
        {
            try
            {
                var stateData = await this.httpClient.PostAsJsonAsync<StateInfoDto>("api/StateInfo/addState",stateInfo);

               var retdata= await stateData.Content.ReadFromJsonAsync<StateInfoDto>();

                return retdata;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<bool> DeleteState(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<StateInfoDto> GetState(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StateInfoDto>> GetStates()
        {
            try
            {
                var stateDataList = await this.httpClient.GetFromJsonAsync<IEnumerable<StateInfoDto>>("api/StateInfo/getStateInfo");

                return stateDataList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            


           // throw new NotImplementedException();
        }

        public async Task<StateInfoDto> UpdateState(StateInfoDto stateInfo)
        {
            try
            {
                var stateDataList = await this.httpClient.GetFromJsonAsync<StateInfoDto>("api/StateInfo/updateState");

                return stateDataList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
