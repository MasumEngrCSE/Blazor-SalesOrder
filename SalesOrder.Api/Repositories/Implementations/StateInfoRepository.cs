using Microsoft.EntityFrameworkCore;
using SalesOrder.Api.Data;
using SalesOrder.Api.Entities;
using SalesOrder.Api.Repositories.Interfaces;
using SalesOrder.Models.Dtos;
using System.Collections.Generic;

namespace SalesOrder.Api.Repositories.Implementations
{
    public class StateInfoRepository : IStateInfoRepository
    {
        private readonly SalesOrderDBContext _DBContext;
        public StateInfoRepository(SalesOrderDBContext salesOrderDBContext)
        {
            _DBContext = salesOrderDBContext;
        }
        public async Task<StateInfoDto> AddState(StateInfoDto stateInfo)
        {
            //throw new NotImplementedException();

            try
            {
                var obj = new StateInfo();
                //obj.Id = stateInfo.Id;
                obj.Name = stateInfo.Name;
                obj.Description = stateInfo.Description;
                obj.CreatedDate = DateTime.Now;
                obj.CreatedBy=stateInfo.CreatedBy;

                this._DBContext.AddAsync(obj);
                this._DBContext.SaveChangesAsync();

                stateInfo.Id = obj.Id;
                stateInfo.CreatedDate=obj.CreatedDate;

                return stateInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<bool> DeleteState(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<StateInfoDto> GetState(int Id)
        {
            try
            {
                //var data =await _DBContext.stateInfo.FirstOrDefaultAsync(p => p.Id == Id);

                var data = await (from p in this._DBContext.stateInfo.Where(p => p.Id == Id)
                                  select new StateInfoDto
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      Description = p.Description,
                                  }).FirstOrDefaultAsync();

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

        public Task<StateInfoDto> UpdateState(StateInfoDto stateInfo)
        {
            throw new NotImplementedException();
        }
    }
}
