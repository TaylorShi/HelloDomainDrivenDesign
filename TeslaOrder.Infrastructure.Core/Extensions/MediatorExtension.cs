using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaOrder.Domain.Abstractions;

namespace TeslaOrder.Infrastructure.Core.Extensions
{
    public static class MediatorExtension
    {
        /// <summary>
        /// 调度领域事件
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx)
        {
            // 从上下文中跟踪实体
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            // 从跟踪实体中获取到事件
            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            // 将实体取出将实体内的事件清除
            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            // 将事件逐条的通过中间者发送出去
            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
