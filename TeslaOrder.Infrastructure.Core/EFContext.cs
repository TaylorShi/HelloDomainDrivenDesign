using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using TeslaOrder.Infrastructure.Core.Extensions;

namespace TeslaOrder.Infrastructure.Core
{
    /// <summary>
    /// EFContext
    /// </summary>
    public class EFContext : DbContext, IUnitOfWork, ITransaction
    {
        protected IMediator _mediator;

        public EFContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }



        #region IUnitOfWork

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            await _mediator.DispatchDomainEventsAsync(this);
            return true;
        }
        #endregion

        #region ITransaction

        private IDbContextTransaction _currentTransaction;

        /// <summary>
        /// 获取当前事务
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        /// <summary>
        /// 判断当前事务是否开启
        /// </summary>
        public bool HasActiveTransaction => _currentTransaction != null;

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;
            _currentTransaction = Database.BeginTransaction();
            return Task.FromResult(_currentTransaction);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        #endregion
    }
}
