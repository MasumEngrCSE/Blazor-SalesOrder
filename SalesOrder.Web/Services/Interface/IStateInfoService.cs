using SalesOrder.Models.Dtos;

namespace SalesOrder.Web.Services.Interface
{
    public interface IStateInfoService
    {
        Task<IEnumerable<StateInfoDto>> GetStates();
        Task<StateInfoDto> GetState(int Id);
        Task<StateInfoDto> AddState(StateInfoDto stateInfo);
        Task<StateInfoDto> UpdateState(StateInfoDto stateInfo);
        Task<bool> DeleteState(int Id);
    }
}
