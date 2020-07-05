using Recodme.RD.FullStoQ.Business.OperationResults;
using Recodme.RD.FullStoQ.Data.Q;
using Recodme.RD.FullStoQ.DataAccess.Q;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.FullStoQ.Business.Q
{
    public class StoreQueueBusinessObject
    {
        private QueueDataAccessObject _dao;

        public StoreQueueBusinessObject()
        {
            _dao = new QueueDataAccessObject();

        }

        #region C

        public OperationResult Create(StoreQueue item)
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
        public async Task<OperationResult> CreateAsync(StoreQueue item)
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

        #region R

        public OperationResult<StoreQueue> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<StoreQueue>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<StoreQueue>() { Success = false, Exception = e };

            }


        }

        public async Task<OperationResult<StoreQueue>> ReadAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<StoreQueue>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<StoreQueue>() { Success = false, Exception = e };

            }

        }

        #endregion

        #region U

        public OperationResult Update(StoreQueue item)
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
        public async Task<OperationResult> UpdateAsync(StoreQueue item)
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

        #region D

        public OperationResult Delete(StoreQueue item)
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
        public async Task<OperationResult> DeleteAsync(StoreQueue item)
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

        #region L

        public OperationResult<List<StoreQueue>> List()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                _dao.List();
                transactionScope.Complete();

                return new OperationResult<List<StoreQueue>>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<List<StoreQueue>>() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult<List<StoreQueue>>> ListAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                await _dao.ListAsync();
                transactionScope.Complete();

                return new OperationResult<List<StoreQueue>>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<List<StoreQueue>>() { Success = false, Exception = e };

            }
        }

        #endregion
    }
}
