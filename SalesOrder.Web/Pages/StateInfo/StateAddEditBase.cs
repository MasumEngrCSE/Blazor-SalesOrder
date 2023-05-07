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
        public StateInfoDto stateInfoModel { get; set; } = default!;

        [Parameter]
        public EventCallback ValidSubmit { get; set; } = default!;



        [Parameter]
        public int stateId { get; set; } 


        protected override async Task OnInitializedAsync()
        {
            //stateInfos = await stateInfoService.GetStates();
            //return base.OnInitializedAsync();
        }


        [Parameter]
        public Action<bool> FromChildCloseAction { get; set; }




        public void closePage()
        {
            FromChildCloseAction(true);
        }

        public void SateAddEdit()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
