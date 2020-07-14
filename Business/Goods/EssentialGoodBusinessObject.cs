using Recodme.RD.FullStoQ.Business.OperationResults;
using Recodme.RD.FullStoQ.Data.Goods;
using Recodme.RD.FullStoQ.DataAccess.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.FullStoQ.Business.Goods
{
    public class EssentialGoodBusinessObject
    {
        private readonly EssentialGoodDataAccessObject _dao;

        public EssentialGoodBusinessObject()
        {
            _dao = new EssentialGoodDataAccessObject();

        }

        #region Create

        public OperationResult Create(EssentialGood item)
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
        public async Task<OperationResult> CreateAsync(EssentialGood item)
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

        public OperationResult<EssentialGood> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<EssentialGood>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<EssentialGood>() { Success = false, Exception = e };

            }


        }

        public async Task<OperationResult<EssentialGood>> ReadAsync(Guid id)
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
                return new OperationResult<EssentialGood>() { Success = true, Result = res };

            }
            catch (Exception e)
            {
                return new OperationResult<EssentialGood>() { Success = false, Exception = e };

            }

        }

        #endregion

        #region Update

        public OperationResult Update(EssentialGood item)
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
        public async Task<OperationResult> UpdateAsync(EssentialGood item)
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

        public OperationResult Delete(EssentialGood item)
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
        public async Task<OperationResult> DeleteAsync(EssentialGood item)
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

        #endregion

        #region List

        public OperationResult<List<EssentialGood>> List()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List();

                transactionScope.Complete();

                return new OperationResult<List<EssentialGood>>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<List<EssentialGood>>() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult<List<EssentialGood>>> ListAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ListAsync();
                transactionScope.Complete();
                return new OperationResult<List<EssentialGood>>() { Success = true, Result = res };

            }
            catch (Exception e)
            {
                return new OperationResult<List<EssentialGood>>() { Success = false, Exception = e };

            }
        }

        #endregion

        #region List Not Deleted
        public OperationResult<List<EssentialGood>> ListNotDeleted()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List().Where(x => !x.IsDeleted).ToList();

                transactionScope.Complete();

                return new OperationResult<List<EssentialGood>>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<List<EssentialGood>>() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult<List<EssentialGood>>> ListNotDeletedAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ListAsync();
                var result = res.Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();
                return new OperationResult<List<EssentialGood>>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<List<EssentialGood>>() { Success = false, Exception = e };

            }
        }
        #endregion
    }
}
