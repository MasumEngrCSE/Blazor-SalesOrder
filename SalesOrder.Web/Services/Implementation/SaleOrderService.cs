﻿using SalesOrder.Models.Dtos;
using SalesOrder.Web.Services.Interface;
using System.Net.Http.Json;

namespace SalesOrder.Web.Services.Implementation
{
    
    public class SaleOrderService : ISaleOrderService
    {
        private readonly HttpClient httpClient;
        public SaleOrderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<SalesOrderDto> AddSalesOrder(SalesOrderDto salesOrder)
        {
            try
            {
                //var ret = new SalesOrderDto();

                var stateData = await this.httpClient.PostAsJsonAsync<SalesOrderDto>("api/SalesOrder/addSalesOrder", salesOrder);

                var retdata = await stateData.Content.ReadFromJsonAsync<SalesOrderDto>();

                return salesOrder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //throw new NotImplementedException();
        }

        public async Task<bool> DeleteSalesOrder(int Id)
        {
            try
            {
                HttpResponseMessage response = await this.httpClient.DeleteAsync($"api/SalesOrder/deleteSalesOrder/{Id}");

                response.EnsureSuccessStatusCode(); 
                // Throws an exception if the response is not successful (e.g., 4xx or 5xx status code)

                bool isDeleted = response.Content.ReadFromJsonAsync<bool>().Result;

                return isDeleted;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<SalesOrderDto> GetSalesOrder(int Id)
        {
            try
            {
                var stateDataList = await this.httpClient.GetFromJsonAsync<SalesOrderDto>($"api/SalesOrder/getSalesOrder/{Id}");
                //var ret = new SalesOrderDto();

               // ret.Id = Id;


                return stateDataList;
            }
            catch (Exception wx)
            {

                throw wx;
            }
        }

        public async Task<IEnumerable<SalesOrderDto>> GetSalesOrders()
        {
            try
            {
                var dataList = await this.httpClient.GetFromJsonAsync<IEnumerable<SalesOrderDto>>("api/SalesOrder/getSalesOrders");

                //var dataList =new List<SalesOrderDto>();


                return dataList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //throw new NotImplementedException();
        }

        public async Task<SalesOrderDto> UpdateSalesOrder(SalesOrderDto salesOrder)
        {
            try
            {
                //var ret = new SalesOrderDto();

                var stateData = await this.httpClient.PostAsJsonAsync<SalesOrderDto>("api/SalesOrder/updateSalesOrder", salesOrder);

                var retdata = await stateData.Content.ReadFromJsonAsync<SalesOrderDto>();

                return salesOrder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
