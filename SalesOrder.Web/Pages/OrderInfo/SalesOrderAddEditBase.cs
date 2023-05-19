using Microsoft.AspNetCore.Components;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Implementation;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Pages.OrderInfo
{
    public class SalesOrderAddEditBase : ComponentBase
    {
        [Parameter]
        public SalesOrderDto salesOrderModel { get; set; } = default!;

        [Parameter]
        public EventCallback ValidSubmit { get; set; } = default!;

        public IEnumerable<StateInfoDto> stateInfos { get; set; }
        public IEnumerable<SalesOrderDto> SalesOrderInfos { get; set; }

        [Parameter]
        public int selectedId { get; set; }


        [Parameter]
        public Action<IEnumerable<SalesOrderDto>> FromChildCloseAction { get; set; } = default!;

        [Inject]
        public IStateInfoService stateInfoService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            salesOrderModel=new SalesOrderDto();
            //stateInfos=new List<StateInfoDto>();
            stateInfos = await stateInfoService.GetStates();
            //if (stateId > 0)
            //    stateInfoModel = await stateInfoService.GetState(stateId);
        }

        public async Task SalesOrderAddEdit()
        {
            try
            {
                if (selectedId > 0)
                {
                    //stateInfoModel = await stateInfoService.UpdateState(stateInfoModel);
                    await closePage();

                }
                else
                {
                    //stateInfoModel = await stateInfoService.AddState(stateInfoModel);
                    await closePage();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task closePage()
        {

            //var stateInfos = await stateInfoService.GetStates();
            FromChildCloseAction(SalesOrderInfos);
        }

    }
}
