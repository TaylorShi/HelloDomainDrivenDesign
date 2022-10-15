using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.Abstractions;
using TeslaOrder.Domain.OrderAggregate;

namespace TeslaOrder.Domain.Events
{
    public class OrderCreatedDomainEvent : IDomainEvent
    {
        public Order Order { get; private set; }
        public OrderCreatedDomainEvent(Order order)
        {
            this.Order = order;
        }
    }
}
