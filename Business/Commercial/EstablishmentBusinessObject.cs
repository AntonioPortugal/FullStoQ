using Recodme.RD.FullStoQ.Business.OperationResults;
using Recodme.RD.FullStoQ.DataAccess.Commercial;
using System;
using System.Threading.Tasks;
using System.Transactions;
using System.Collections.Generic;
using Recodme.RD.FullStoQ.Data.Commercial;
using System.Linq;

namespace Recodme.RD.FullStoQ.Business.Commercial
{
    public class EstablishmentBusinessObject : OperationResult
    {
        private readonly EstablishmentDataAccessObject _dao;
        public EstablishmentBusinessObject()
        {
            _dao = new EstablishmentDataAccessObject();
        }    

        #region List
        public OperationResult<List<Establishment>> List()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using var ts = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                
                var result = _dao.List().Where(x => !x.IsDeleted).ToList();
                ts.Complete();
                return new OperationResult<List<Establishment>>() { Success = true, Result = result };
                
            }
            catch (Exception e)
            {
                return new OperationResult<List<Establishment>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<Establishment>>> ListAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using var ts = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);

                var res = await _dao.ListAsync();
                var result = res.Where(x => !x.IsDeleted).ToList();
                ts.Complete();
                return new OperationResult<List<Establishment>>() { Success = true, Result = result };
                
            }
            catch (Exception e)
            {
                return new OperationResult<List<Establishment>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Create
        public OperationResult Create(Establishment establishment)
        {
            try
            {

                _dao.Create(establishment);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> CreateAsync(Establishment establishment)
        {
            try
            {
                await _dao.CreateAsync(establishment);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<Establishment> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                
                var res = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<Establishment>() { Success = true, Result = res };
                
            }
            catch (Exception e)
            {
                return new OperationResult<Establishment>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<Establishment>> ReadAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                
                var res = await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<Establishment>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<Establishment>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Establishment establishment)
        {
            try
            {
                _dao.Update(establishment);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> UpdateAsync(Establishment establishment)
        {
            try
            {
                await _dao.UpdateAsync(establishment);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = true, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(Establishment establishment)
        {
            try
            {
                _dao.Delete(establishment);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = true, Exception = e };
            }
        }
        public async Task<OperationResult> DeleteAsync(Establishment establishment)
        {
            try
            {
                await _dao.DeleteAsync(establishment);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = true, Exception = e };
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
                return new OperationResult() { Success = true, Exception = e };
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
                return new OperationResult() { Success = true, Exception = e };
            }
        }
        #endregion
    }
}
