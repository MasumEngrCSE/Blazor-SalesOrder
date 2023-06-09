using Microsoft.AspNetCore.Components;
//using Microsoft.JSInterop;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Implementation;
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
        public Action<IEnumerable<StateInfoDto>> FromChildCloseAction { get; set; } = default!;





        protected override async Task OnInitializedAsync()
        {
            //stateInfoModel = new StateInfoDto();
            //if (stateId > 0)
            //    stateInfoModel = await stateInfoService.GetState(stateId);
        }


        protected override async Task OnParametersSetAsync()
        {
            stateInfoModel = new StateInfoDto();
            if (stateId > 0)
                stateInfoModel = await stateInfoService.GetState(stateId);
        }




        public async Task closePage()
        {

           var stateInfos = await stateInfoService.GetStates();
            FromChildCloseAction(stateInfos);
        }

        public async Task SateAddEdit()
        {
            try
            {
                if (stateId > 0)
                {
                    stateInfoModel = await stateInfoService.UpdateState(stateInfoModel);
                    await closePage();

                    //await JsRuntime.InvokeVoidAsync("alert", "Warning!");
                    //await js.InvokeVoidAsync("alert", $"Updated Successfully!");
                }
                else
                {
                    stateInfoModel = await stateInfoService.AddState(stateInfoModel);
                    await closePage();
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
