using Microsoft.AspNetCore.Components;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Pages.StateInfo
{
    public class StateInfoBase:ComponentBase
    {
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
            AddEditShowed=true;
            selectedStateId = 0;
           // FromChild("Value From Child:" + DateTime.Now);
        }
    }
}
