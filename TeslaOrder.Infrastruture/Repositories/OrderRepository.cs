using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.OrderAggregate;
using TeslaOrder.Infrastructure.Core;

namespace TeslaOrder.Infrastruture.Repositories
{
    /// <summary>
    /// 订单仓储
    /// </summary>
    public class OrderRepository : Repository<Order, long, DomainContext>, IOrderRepository
    {
        public OrderRepository(DomainContext context) : base(context)
        {

        }
    }
}
