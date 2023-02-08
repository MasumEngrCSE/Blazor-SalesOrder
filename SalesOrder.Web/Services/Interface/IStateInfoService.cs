using SalesOrder.Models.Dtos;

namespace SalesOrder.Web.Services.Interface
{
    public interface IStateInfoService
    {
        Task<IEnumerable<StateInfoDto>> GetStates();
    }
}
