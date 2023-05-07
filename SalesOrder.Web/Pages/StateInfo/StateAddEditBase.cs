using Microsoft.AspNetCore.Components;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Pages.StateInfo
{
    public class StateAddEditBase : ComponentBase
    {
        [Inject]
        public IStateInfoService stateInfoService { get; set; }

        public IEnumerable<StateInfoDto> stateInfos { get; set; }



        [Parameter]
        public int stateId { get; set; } 


        protected override async Task OnInitializedAsync()
        {
            //stateInfos = await stateInfoService.GetStates();
            //return base.OnInitializedAsync();
        }
    }
}
