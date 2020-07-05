using Recodme.RD.FullStoQ.Business.OperationResults;
using Recodme.RD.FullStoQ.DataAccess.Commercial;
using System;
using System.Threading.Tasks;
using System.Transactions;
using System.Collections.Generic;

namespace Recodme.RD.FullStoQ.Business.Commercial
{
    public class EstablishmentBusinessObject : OperationResult
    {
        private EstablishmentDataAccessObject _dao;
        public EstablishmentBusinessObject()
        {
            _dao = new EstablishmentDataAccessObject();
        }

       private readonly TransactionOptions transactionOptions = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        #region Count
        public OperationResult<int> CountAll()
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                    TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = _dao.List().Count;
                    scope.Complete();
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
                using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, 
                    TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = await _dao.ListAsync();
                    scope.Complete();
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
