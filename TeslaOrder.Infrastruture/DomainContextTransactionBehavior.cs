using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Infrastructure.Core.Behaviors;

namespace TeslaOrder.Infrastruture
{
    public class DomainContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<DomainContext, TRequest, TResponse>
    {
        public DomainContextTransactionBehavior(DomainContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }
    }
}
