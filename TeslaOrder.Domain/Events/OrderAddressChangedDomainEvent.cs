using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.Abstractions;
using TeslaOrder.Domain.OrderAggregate;

namespace TeslaOrder.Domain.Events
{
    public class OrderAddressChangedDomainEvent : IDomainEvent
    {
        public Address Address { get; private set; }
        public OrderAddressChangedDomainEvent(Address address)
        {
            this.Address = address;
        }
    }
}
