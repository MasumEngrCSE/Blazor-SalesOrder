using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Pages.StateInfo
{
    public class StateAddEditBase : ComponentBase
    {
        [Inject]
        public IStateInfoService stateInfoService { get; set; } = default!;

        public IEnumerable<StateInfoDto> stateInfos { get; set; } = default!;

        [Parameter]
        public StateInfoDto stateInfoModel { get; set; } = default!;

        [Parameter]
        public EventCallback ValidSubmit { get; set; } = default!;



        [Parameter]
        public int stateId { get; set; }

        [Parameter]
        public Action<bool> FromChildCloseAction { get; set; } = default!;





        protected override async Task OnInitializedAsync()
        {
            //stateInfos = await stateInfoService.GetStates();
            //return base.OnInitializedAsync();
            stateInfoModel = new StateInfoDto();
            if (stateId > 0)
                stateInfoModel = await stateInfoService.GetState(stateId);
        }







        public void closePage()
        {
            FromChildCloseAction(true);
        }

        public async Task SateAddEdit()
        {
            try
            {
                if (stateId > 0)
                {
                    stateInfoModel = await stateInfoService.UpdateState(stateInfoModel);

                    //await js.InvokeVoidAsync("alert", $"Updated Successfully!");

                    

                }
                else
                {
                    stateInfoModel = await stateInfoService.AddState(stateInfoModel);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
