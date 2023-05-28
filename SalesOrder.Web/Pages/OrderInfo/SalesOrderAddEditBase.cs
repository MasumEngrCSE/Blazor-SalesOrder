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
        public ISaleOrderService saleOrderService { get; set; }

        [Inject]
        public IStateInfoService stateInfoService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            salesOrderModel=new SalesOrderDto();
            salesOrderModel.SalesOrderWindowList = new List<SalesOrderWindowDto>();
            salesOrderModel.WindowSubElementList = new List<WindowSubElementDto>();


            //stateInfos=new List<StateInfoDto>();
            stateInfos = await stateInfoService.GetStates();
            if (selectedId > 0)
                salesOrderModel = await saleOrderService.GetSalesOrder(selectedId);
        }

        public async Task SalesOrderAddEdit()
        {
            try
            {
                if (selectedId > 0)
                {
                    salesOrderModel = await saleOrderService.UpdateSalesOrder(salesOrderModel);
                    await closePage();

                }
                else
                {
                    salesOrderModel.OrderDate = DateTime.Now;

                    salesOrderModel = await saleOrderService.AddSalesOrder(salesOrderModel);
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

            SalesOrderInfos = await saleOrderService.GetSalesOrders();


            FromChildCloseAction(SalesOrderInfos);
        }


        public void receiveFromWindow(SalesOrderDto salesOrderModel)
        {
            //logString3 = "Com 3 Button Press on" + DateTime.Now;
            StateHasChanged();
        }

    }
}
