using Microsoft.EntityFrameworkCore;
using SalesOrder.Api.Data;
using SalesOrder.Api.Entities;
using SalesOrder.Api.Repositories.Interfaces;
using SalesOrder.Models.Dtos;
using System.Collections.Generic;

namespace SalesOrder.Api.Repositories.Implementations
{
    public class SateInfoRepository : ISateInfoRepository
    {
        private readonly SalesOrderDBContext _DBContext;
        public SateInfoRepository(SalesOrderDBContext salesOrderDBContext)
        {
            _DBContext = salesOrderDBContext;
        }
        public Task<StateInfo> AddState(StateInfo stateInfo)
        {
            throw new NotImplementedException();
        }

        public Task<StateInfo> DeleteState(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<StateInfo> GetState(int Id)
        {
            try
            {
                var data =await _DBContext.stateInfo.FirstOrDefaultAsync(p => p.Id == Id);

                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<StateInfoDto>> GetStates()
        {
            
            try
            {
                var data =await(from p in  this._DBContext.stateInfo
                          select new StateInfoDto
                          {
                              Id=p.Id,
                              Name=p.Name,
                              Description=p.Description,
                          }).ToListAsync();


                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<StateInfo> UpdateState(StateInfo stateInfo)
        {
            throw new NotImplementedException();
        }
    }
}
