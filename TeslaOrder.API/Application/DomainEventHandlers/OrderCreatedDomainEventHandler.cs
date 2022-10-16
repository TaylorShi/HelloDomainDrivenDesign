
using System.Threading.Tasks;
using System.Threading;
using TeslaOrder.Domain.Abstractions;
using TeslaOrder.Domain.Events;
using TeslaOrder.API.Application.IntegrationEvents;

namespace TeslaOrder.API.Application.DomainEventHandlers
{
    public class OrderCreatedDomainEventHandler : IDomainEventHandler<OrderCreatedDomainEvent>
    {
        //ICapPublisher _capPublisher;
        //public OrderCreatedDomainEventHandler(ICapPublisher capPublisher)
        //{
        //    _capPublisher = capPublisher;
        //}

        public async Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            //await _capPublisher.PublishAsync("OrderCreated", new OrderCreatedIntegrationEvent(notification.Order.Id));
        }
    }
}
