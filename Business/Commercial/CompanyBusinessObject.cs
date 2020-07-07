using Recodme.RD.FullStoQ.Business.OperationResults;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.DataAccess.Commercial;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.FullStoQ.Business.Commercial
{
    public class CompanyBusinessObject
    {
        private readonly CompanyDataAccessObject _dao;

        public CompanyBusinessObject()
        {
            _dao = new CompanyDataAccessObject();
        }

        private readonly TransactionOptions opts = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        #region Create
        public OperationResult Create(Company item)
        {
            try
            {
                _dao.Create(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult> CreateAsync(Company item)
        {
            try
            {
                await _dao.CreateAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<Company> Read(Guid id)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = _dao.Read(id);
                    scope.Complete();
                    return new OperationResult<Company>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<Company>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Company>> ReadAsync(Guid id)
        {
            try
            {
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ReadAsync(id);
                    transactionScope.Complete();
                    return new OperationResult<Company>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<Company>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Company item)
        {
            try
            {
                _dao.Update(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult> UpdateAsync(Company item)
        {
            try
            {
                await _dao.UpdateAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(Company item)
        {
            try
            {
                _dao.Delete(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public OperationResult Delete(Guid id)
        {
            try
            {
                _dao.Delete(id);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult> DeleteAsync(Company item)
        {
            try
            {
                await _dao.DeleteAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            try
            {
                await _dao.DeleteAsync(id);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region List
        public OperationResult<List<Company>> List()
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    _dao.List();
                    scope.Complete();
                    return new OperationResult<List<Company>>() { Success = true };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<Company>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<Company>>> ListAsync()
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    await _dao.ListAsync();
                    scope.Complete();
                    return new OperationResult<List<Company>>() { Success = true };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<Company>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Count All
        public OperationResult<int> CountAll()
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
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
                using (var scope = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
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
