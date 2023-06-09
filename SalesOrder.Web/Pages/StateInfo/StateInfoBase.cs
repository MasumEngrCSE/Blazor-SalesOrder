using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Pages.OrderInfo;
using SalesOrder.Web.Services.Implementation;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Pages.StateInfo
{
    public class StateInfoBase:ComponentBase
    {
        public bool showModal = false;
        private bool IsAddEditShowed=false;
        public bool AddEditShowed { get { return IsAddEditShowed; } set { IsAddEditShowed = value; } }

        public int selectedStateId;


        [Inject]
        public IStateInfoService stateInfoService { get; set; }

        public IEnumerable<StateInfoDto> stateInfos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            stateInfos = await stateInfoService.GetStates();
            //return base.OnInitializedAsync();
        }


        public void  showAddEdit()
        {
            //AddEditShowed=true;
            selectedStateId = 0;
            showModal = true;


            // FromChild("Value From Child:" + DateTime.Now);
        }

        public void showStateEdit(int Id)
        {
            //AddEditShowed = true;
            selectedStateId = Id;
            showModal = true;


            // FromChild("Value From Child:" + DateTime.Now);
        }


        public void showSalesInfo(IEnumerable<StateInfoDto> stateInfosData)
        {
            //bool isCloseSalesInfo
            //AddEditShowed = !isCloseSalesInfo;
            AddEditShowed = false;
            selectedStateId = 0;
            //stateInfos = await stateInfoService.GetStates();
            stateInfos = stateInfosData;
            // showData();
            showModal = false;
            modal.HideAsync();
            StateHasChanged();
        }


        private async Task showData()
        {
            stateInfos = await stateInfoService.GetStates();
        }


        #region New Modal
        public string AddEditTitle { get; set; }
        public Modal modal = default!;
        private string? message;
        public async Task OnAddClick()
        {
            AddEditTitle = "Add State";
            selectedStateId = 0;
            var parameters = new Dictionary<string, object>();
            parameters.Add("stateId", selectedStateId);
            parameters.Add("FromChildCloseAction", showSalesInfo);
            await modal.ShowAsync<StateAddEdit>(title: AddEditTitle, parameters: parameters);


        }

        public async void OnShowEdit(int Id)
        {
            AddEditTitle = "Edit State";
            selectedStateId = Id;
            var parameters = new Dictionary<string, object>();
            parameters.Add("stateId", selectedStateId);
            parameters.Add("FromChildCloseAction", showSalesInfo);
            await modal.ShowAsync<StateAddEdit>(title: AddEditTitle, parameters: parameters);
        }

        private void ShowDTMessage(MouseEventArgs e) => message = $"The current DT is: {DateTime.Now}.";





        public void OnModalHiding()
        {

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


    }
}
