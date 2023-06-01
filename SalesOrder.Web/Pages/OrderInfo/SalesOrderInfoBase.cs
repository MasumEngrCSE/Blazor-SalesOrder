using Microsoft.AspNetCore.Components;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Implementation;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Pages.OrderInfo
{
    public partial class SalesOrderInfoBase : ComponentBase
    {
        public IEnumerable<SalesOrderDto> salesOrders { get; set; }
        //public SalesOrderDto salesOrderModel { get; set; } = default!;
        public bool showModal = false;
        private bool IsAddEditShowed = false;
        public int selectedId = 0;
        public bool AddEditShowed { get { return IsAddEditShowed; } set { IsAddEditShowed = value; } }

        public string AddEditTitle { get; set; }

        [Inject]
        public ISaleOrderService saleOrderService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //salesOrders = await stateInfoService.GetStates();
            salesOrders = new List<SalesOrderDto>();

            salesOrders = await saleOrderService.GetSalesOrders();
        }

        public void showAdd()
        {
            AddEditTitle = "Add Sales Order";
            selectedId = 0;
            showModal = true;

        }

        public async void showEdit(int Id)
        {
            AddEditTitle = "Edit Sales Order";
            selectedId = Id;
            //salesOrderModel= await saleOrderService.GetSalesOrder(Id);
            showModal = true;
            StateHasChanged();
        }

        public async void delete(SalesOrderDto row)
        {
            //selectedId = 0;
            bool isDeleted = await saleOrderService.DeleteSalesOrder(row.Id);
            if (isDeleted)
            {
                salesOrders = await saleOrderService.GetSalesOrders();
                StateHasChanged();
            }
        }


        public void closeAction(IEnumerable<SalesOrderDto> salesOrdersData)
        {
            AddEditShowed = false;
            selectedId = 0;

            if (salesOrdersData != null)
                salesOrders = salesOrdersData;

            showModal = false;

            StateHasChanged();
        }
    }
}
