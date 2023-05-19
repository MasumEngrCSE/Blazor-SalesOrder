using Microsoft.AspNetCore.Components;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Implementation;

namespace SalesOrder.Web.Pages.OrderInfo
{
    public partial class SalesOrderInfoBase : ComponentBase
    {
        public IEnumerable<SalesOrderDto> salesOrders { get; set; }
        public bool showModal = false;
        private bool IsAddEditShowed = false;
        public int selectedId = 0;
        public bool AddEditShowed { get { return IsAddEditShowed; } set { IsAddEditShowed = value; } }

        public string AddEditTitle { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //salesOrders = await stateInfoService.GetStates();
            salesOrders = new List<SalesOrderDto>();
        }

        public void showAdd()
        {
            AddEditTitle = "Add Sales Order";
            selectedId = 0;
            showModal = true;

        }

        public void showEdit(int Id)
        {
            AddEditTitle = "Edit Sales Order";
            selectedId = Id;
            showModal = true;
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
