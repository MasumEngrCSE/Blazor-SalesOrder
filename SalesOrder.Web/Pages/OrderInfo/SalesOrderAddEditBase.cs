﻿using Microsoft.AspNetCore.Components;
using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Implementation;
using SalesOrder.Web.Services.Interface;

namespace SalesOrder.Web.Pages.OrderInfo
{
    public class SalesOrderAddEditBase : ComponentBase
    {
        //[Parameter]
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
            salesOrderModel.SalesOrderWindowList = new List<SalesOrderDto>();
            salesOrderModel.WindowSubElementList = new List<SalesOrderDto>();


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
                    salesOrderModel = await saleOrderService.UpdateSalesOrder(salesOrderModel);
                    await closePage();

                }
                else
                {
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

            //var stateInfos = await stateInfoService.GetStates();
            FromChildCloseAction(SalesOrderInfos);
        }

    }
}
