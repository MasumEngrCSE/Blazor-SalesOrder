using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SalesOrder.Models.Dtos;
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
           
            StateHasChanged();
        }


        private async Task showData()
        {
            stateInfos = await stateInfoService.GetStates();
        }

    }
}
