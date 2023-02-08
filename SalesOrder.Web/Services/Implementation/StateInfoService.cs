using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Services.Implementation
{
    public class StateInfoService: IStateInfoService
    {
        private readonly HttpClient httpClient;

        public StateInfoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<IEnumerable<StateInfoDto>> GetStates()
        {
            throw new NotImplementedException();
        }
    }
}
