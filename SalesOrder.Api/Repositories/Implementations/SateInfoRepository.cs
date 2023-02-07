using Microsoft.EntityFrameworkCore;
using SalesOrder.Api.Data;
using SalesOrder.Api.Entities;
using SalesOrder.Api.Repositories.Interfaces;

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

        public Task<IEnumerable<StateInfo>> GetStates()
        {
            throw new NotImplementedException();
        }

        public Task<StateInfo> UpdateState(StateInfo stateInfo)
        {
            throw new NotImplementedException();
        }
    }
}
