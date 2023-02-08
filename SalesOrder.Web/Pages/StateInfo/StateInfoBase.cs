using Microsoft.AspNetCore.Components;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Pages.StateInfo
{
    public class StateInfoBase:ComponentBase
    {
        [Inject]
        public IStateInfoService stateInfoService { get; set; }
    }
}
