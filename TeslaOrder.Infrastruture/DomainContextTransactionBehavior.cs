using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Infrastructure.Core.Behaviors;

namespace TeslaOrder.Infrastruture
{
    /// <summary>
    /// 领域事务行为管理类
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class DomainContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<DomainContext, TRequest, TResponse>
    {
        public DomainContextTransactionBehavior(DomainContext dbContext, ILogger<DomainContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, logger)
        {

        }
    }
}
