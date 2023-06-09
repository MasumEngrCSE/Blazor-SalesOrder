using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Implementation;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Pages.OrderInfo
{
    public class SalesOrderAddEditBase : ComponentBase
    {
        [Parameter]
        public int selectedId { get; set; }

        [Parameter]
        public Action<IEnumerable<SalesOrderDto>,string> FromChildCloseAction { get; set; } = default!;
        //public Action<IEnumerable<SalesOrderDto>> FromChildCloseAction { get; set; } = default!;


        [Inject]
        public ISaleOrderService saleOrderService { get; set; }

        [Inject]
        public IStateInfoService stateInfoService { get; set; }

        /// <summary>
        /// /end paramiter & Inject
        /// </summary>
 

        //[Parameter]
        public SalesOrderDto salesOrderModel { get; set; } = default!;

        //[Parameter]
        //public EventCallback ValidSubmit { get; set; } = default!;


        public void ValidSubmit()
        {
           // Logger.LogInformation("HandleValidSubmit called");

            // Process the valid form
        }

        public IEnumerable<StateInfoDto> stateInfos { get; set; }
        public IEnumerable<SalesOrderDto> SalesOrderInfos { get; set; }
        public DateTime OrderDate { get; set; }= DateTime.Now;

        protected override async Task OnInitializedAsync()
        {
            salesOrderModel = new SalesOrderDto();
            salesOrderModel.SalesOrderWindowList = new List<SalesOrderWindowDto>();
            salesOrderModel.WindowSubElementList = new List<WindowSubElementDto>();

            stateInfos = await stateInfoService.GetStates();
            //OrderDate = DateTime.Now;

            //salesOrderModel.OrderDate=DateTime.Now;
        }
        protected override async Task OnParametersSetAsync()
        {
            if (selectedId > 0)
            {
                salesOrderModel = await saleOrderService.GetSalesOrder(selectedId);
                OrderDate = salesOrderModel.OrderDate??DateTime.Now;
            }
            //return base.OnParametersSetAsync();
        }



        public async Task SalesOrderAddEdit()
        {
            try
            {
                salesOrderModel.OrderDate = OrderDate;
                if (selectedId > 0)
                {
                    salesOrderModel = await saleOrderService.UpdateSalesOrder(salesOrderModel);
                    //ShowMessage(ToastType.Info, "Successfully Updated.");

                    await closePage("U");

                }
                else
                {
                    

                    salesOrderModel = await saleOrderService.AddSalesOrder(salesOrderModel);
                    
                    //ShowMessage(ToastType.Info, "Successfully Added.");
                    await closePage("I");
                }

            }
            catch (Exception ex)
            {
                await closePage("E");
                throw ex;
            }
        }

        //public void FieldChanged(string fieldName)
        //{
        //    //CustomerChanged.InvokeAsync(Customer);
        //    isInvalid = !inputWatcher.Validate();
        //}

        //public InputWatcher inputWatcher = default!;
        //public bool isInvalid = true;



        public async Task closePage(string tStatus = "")
        {

            SalesOrderInfos = await saleOrderService.GetSalesOrders();

            ////SalesOrderInfos.tst

            FromChildCloseAction(SalesOrderInfos, tStatus);
        }


        public void receiveFromWindow(SalesOrderDto salesOrderModel)
        {
            //logString3 = "Com 3 Button Press on" + DateTime.Now;
            StateHasChanged();
        }


        public List<ToastMessage> messages = new List<ToastMessage>();
        public void ShowMessage(ToastType toastType, string message) => messages.Add(CreateToastMessage(toastType, message));

        public ToastMessage CreateToastMessage(ToastType toastType, string message)
        => new ToastMessage
        {
            Type = toastType,
            Title = "Blazor Bootstrap",
            HelpText = $"{DateTime.Now}",
            Message = message,
        };


    }
}
