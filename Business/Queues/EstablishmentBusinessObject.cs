using Recodme.RD.FullStoQ.Business.OperationResults;
using Recodme.RD.FullStoQ.DataAccess.Queues;
using System;
using System.Threading.Tasks;
using System.Transactions;
using System.Collections.Generic;

namespace Recodme.RD.FullStoQ.Business.Queues
{
    public class EstablishmentBusinessObject : OperationResult
    {
        private EstablishmentDataAccessObject _dao;
        public EstablishmentBusinessObject()
        {
            _dao = new EstablishmentDataAccessObject();
        }

        #region Count
        public OperationResult<int> CountAll()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using (var ts = new TransactionScope(TransactionScopeOption.Required, transactionOptions, 
                    TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = _dao.Count;
                    ts.Complete();
                    return new OperationResult<int>() { Success = true, Result = result };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<int>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<int>> CountAllAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using (var ts = new TransactionScope(TransactionScopeOption.Required, transactionOptions, 
                    TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = await _dao.ListAsync();
                    ts.Complete();
                    return new OperationResult<int>() { Success = true, Result = result.Count };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<int>() { Success = false, Exception = e };
            }
        }
        #endregion 
    }
}
