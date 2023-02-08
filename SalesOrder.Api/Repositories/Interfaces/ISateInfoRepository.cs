using SalesOrder.Api.Entities;
using SalesOrder.Models.Dtos;

namespace SalesOrder.Api.Repositories.Interfaces
{
    public interface ISateInfoRepository
    {
        Task<IEnumerable<StateInfoDto>> GetStates();
        Task<StateInfo> GetState(int Id);
        Task<StateInfo> AddState(StateInfo stateInfo);
        Task<StateInfo> UpdateState(StateInfo stateInfo);
        Task<StateInfo> DeleteState(int Id);

    }
}
