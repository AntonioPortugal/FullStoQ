using Recodme.RD.FullStoQ.Business.OperationResults;
using Recodme.RD.FullStoQ.Data.Base;
using Recodme.RD.FullStoQ.Data.Goods;
using Recodme.RD.FullStoQ.DataAccess.Goods;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.FullStoQ.Business.Goods
{
    public class BrandBusinessObject 
    {
        private readonly BrandDataAccessObject _dao;
        public BrandBusinessObject()
        {
            _dao = new BrandDataAccessObject();
        }

        #region List
        public OperationResult<List<Brand>> List()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, 
                    transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List();

                transactionScope.Complete();

                return new OperationResult<List<Brand>>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Brand>>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<List<Brand>>> ListAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, 
                    transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ListAsync();
                transactionScope.Complete();
                return new OperationResult<List<Brand>>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Brand>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Create
        public OperationResult Create(Brand brand)
        {
            try
            {
                _dao.Create(brand);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> CreateAsync(Brand brand)
        {
            try
            {

                await _dao.CreateAsync(brand);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<Brand> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
                    transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = _dao.Read(id);
                    transactionScope.Complete();
                    return new OperationResult<Brand>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<Brand>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<Brand>> ReadAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
                    transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ReadAsync(id);
                    transactionScope.Complete();
                    return new OperationResult<Brand>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<Brand>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Brand brand)
        {
            try
            {
                _dao.Update(brand);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult> UpdateAsync(Brand brand)
        {
            try
            {
                await _dao.UpdateAsync(brand);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(Brand brand)
        {
            try
            {
                _dao.Delete(brand);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> DeleteAsync(Brand brand)
        {
            try
            {
                await _dao.DeleteAsync(brand);
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
    }
}
