using DotNetCore.CAP;
using MediatR;

namespace TeslaOrder.API.Application.IntegrationEvents
{
    /// <summary>
    /// 订阅服务
    /// </summary>
    public class SubscriberService : ISubscriberService, ICapSubscribe
    {
        IMediator _mediator;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mediator"></param>
        public SubscriberService(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 订阅订单创建成功集成事件
        /// </summary>
        /// <param name="event"></param>
        [CapSubscribe("OrderCreated")]
        public void OrderCreated(OrderCreatedIntegrationEvent @event)
        {
            //Do SomeThing
        }

        /// <summary>
        /// 订阅订单支付成功集成事件
        /// </summary>
        /// <param name="event"></param>
        [CapSubscribe("OrderPaymentSucceeded")]
        public void OrderPaymentSucceeded(OrderPaymentSucceededIntegrationEvent @event)
        {
            //Do SomeThing
        }
    }
}
