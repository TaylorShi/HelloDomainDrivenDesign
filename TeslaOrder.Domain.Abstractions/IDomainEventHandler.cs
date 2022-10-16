using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeslaOrder.Domain.Abstractions
{
    /// <summary>
    /// 领域事件处理接口
    /// </summary>
    /// <typeparam name="TDomainEvent"></typeparam>
    public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        //这里我们使用了INotificationHandler的Handle方法来作为处理方法的定义
        //Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken);
    }
}
