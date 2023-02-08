using Microsoft.AspNetCore.Components;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Pages.StateInfo
{
    public class StateInfoBase:ComponentBase
    {
        [Inject]
        public IStateInfoService stateInfoService { get; set; }

        public IEnumerable<StateInfoDto> stateInfos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            stateInfos = await stateInfoService.GetStates();
            //return base.OnInitializedAsync();
        }
    }
}
