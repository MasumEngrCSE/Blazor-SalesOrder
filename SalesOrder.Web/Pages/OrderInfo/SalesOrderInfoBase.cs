using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SalesOrder.Models.Dtos;
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


            bool isDeleted = await saleOrderService.DeleteSalesOrder(row.Id);
            if (isDeleted)
            {
                salesOrders = await saleOrderService.GetSalesOrders();
                StateHasChanged();
            }
        }


        public void closeAction(IEnumerable<SalesOrderDto> salesOrdersData, string Status)
        {
            AddEditShowed = false;

            if (Status == "I")
                ShowMessage(ToastType.Info, "Successfully Added.");
            else if (Status == "U")
                ShowMessage(ToastType.Info, "Successfully Updated.");
            else if (Status == "E")
                ShowMessage(ToastType.Danger, "Error Raised");

            selectedId = 0;

            if (salesOrdersData != null)
                salesOrders = salesOrdersData;

            showModal = false;
            modal.HideAsync();
            StateHasChanged();
        }



        #region New Modal

        public Modal modal = default!;
        private string? message;
        public async Task OnAddClick()
        {
            AddEditTitle = "Add Sales Order";
            selectedId = 0;
            var parameters = new Dictionary<string, object>();
            parameters.Add("selectedId", selectedId);
            parameters.Add("FromChildCloseAction", closeAction);
            await modal.ShowAsync<SalesOrderAddEdit>(title: AddEditTitle, parameters: parameters);


            //ShowMessage(ToastType.Info, "Successfully Added.");




            //await modal.ShowAsync();

        }

        public async void OnShowEdit(int Id)
        {
            AddEditTitle = "Edit Sales Order";
            selectedId = Id;

            var parameters = new Dictionary<string, object>();
            parameters.Add("selectedId", selectedId);
            parameters.Add("FromChildCloseAction", closeAction);
            await modal.ShowAsync<SalesOrderAddEdit>(title: AddEditTitle, parameters: parameters);

            //ShowMessage(ToastType.Info, "Successfully Updated.");
            //await modal.ShowAsync();
            //salesOrderModel= await saleOrderService.GetSalesOrder(Id);
            //showModal = true;
            //StateHasChanged();
        }

        private void ShowDTMessage(MouseEventArgs e) => message = $"The current DT is: {DateTime.Now}.";





        public void OnModalHiding()
        {

            //ToastService.Notify(new(ToastType.Danger, $"Event: Hiding called. DateTime: {DateTime.Now}"));
        }
        public ConfirmDialog dialog;
        public async Task deleteConfirm(SalesOrderDto row)
        {
            var options = new ConfirmDialogOptions
            {
                YesButtonText = "OK",
                YesButtonColor = ButtonColor.Success,
                NoButtonText = "CANCEL",
                NoButtonColor = ButtonColor.Danger
            };

            var confirmation = await dialog.ShowAsync(
                title: "Sales Order delete",
                message1: $"Do you want delete Sales Order No:{row.OrderTitle}?",
                confirmDialogOptions: options);

            if (confirmation)
            {
                bool isDeleted = await saleOrderService.DeleteSalesOrder(row.Id);
                if (isDeleted)
                {
                    salesOrders = await saleOrderService.GetSalesOrders();
                    StateHasChanged();
                    ShowMessage(ToastType.Danger, "Successfully Deleted.");
                }

                // do whatever
            }
            else
            {
                // do whatever
            }
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

        #endregion



        #region bb grid

        public BlazorBootstrap.Grid<SalesOrderDto> grid;
        public IEnumerable<Employee1> employees;

        //public override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    await base.OnAfterRenderAsync(firstRender);
        //}

        public async Task<GridDataProviderResult<SalesOrderDto>> EmployeesDataProvider(GridDataProviderRequest<SalesOrderDto> request)
        {
            //if (employees is null) // pull employees only one time for client-side filtering, sorting, and paging
            //    employees = GetEmployees(); // call a service or an API to pull the employees



            return await Task.FromResult(request.ApplyTo(salesOrders));
            //return await Task.FromResult(request.ApplyTo(employees));
        }

        private IEnumerable<Employee1> GetEmployees()
        {
            return new List<Employee1>
        {
            new Employee1 { Id = 107, Name = "Alice", Designation = "AI Engineer", DOJ = new DateOnly(1998, 11, 17), IsActive = true },
            new Employee1 { Id = 103, Name = "Bob", Designation = "Senior DevOps Engineer", DOJ = new DateOnly(1985, 1, 5), IsActive = true },
            new Employee1 { Id = 106, Name = "John", Designation = "Data Engineer", DOJ = new DateOnly(1995, 4, 17), IsActive = true },
            new Employee1 { Id = 104, Name = "Pop", Designation = "Associate Architect", DOJ = new DateOnly(1985, 6, 8), IsActive = false },
            new Employee1 { Id = 105, Name = "Ronald", Designation = "Senior Data Engineer", DOJ = new DateOnly(1991, 8, 23), IsActive = true },
            new Employee1 { Id = 102, Name = "Line", Designation = "Architect", DOJ = new DateOnly(1977, 1, 12), IsActive = true },
            new Employee1 { Id = 101, Name = "Daniel", Designation = "Architect", DOJ = new DateOnly(1977, 1, 12), IsActive = true },
            new Employee1 { Id = 108, Name = "Zayne", Designation = "Data Analyst", DOJ = new DateOnly(1991, 1, 1), IsActive = true },
            new Employee1 { Id = 109, Name = "Isha", Designation = "App Maker", DOJ = new DateOnly(1996, 7, 1), IsActive = true },
        };
        }

        #endregion


    }


    public class Employee1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public DateOnly DOJ { get; set; }
        public bool IsActive { get; set; }

    }
}
