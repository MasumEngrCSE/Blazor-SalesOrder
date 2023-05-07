using SalesOrder.Api.Entities;
using SalesOrder.Models.Dtos;

namespace SalesOrder.Api.Repositories.Interfaces
{
    public interface IStateInfoRepository
    {
        Task<IEnumerable<StateInfoDto>> GetStates();
        Task<StateInfoDto> GetState(int Id);
        Task<StateInfoDto> AddState(StateInfoDto stateInfo);
        Task<StateInfoDto> UpdateState(StateInfoDto stateInfo);
        Task<bool> DeleteState(int Id);
    }
}
