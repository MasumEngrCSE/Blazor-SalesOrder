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
    }
}
