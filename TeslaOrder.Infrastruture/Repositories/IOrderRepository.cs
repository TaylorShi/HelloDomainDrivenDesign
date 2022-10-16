using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.OrderAggregate;
using TeslaOrder.Infrastructure.Core;

namespace TeslaOrder.Infrastruture.Repositories
{
    /// <summary>
    /// 订单仓储接口
    /// </summary>
    public interface IOrderRepository : IRepository<Order, long>
    {

    }
}
