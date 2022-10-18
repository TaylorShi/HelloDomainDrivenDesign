namespace TeslaOrder.API.Application.IntegrationEvents
{
    /// <summary>
    /// 订单创建集成事件
    /// </summary>
    public class OrderCreatedIntegrationEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="orderId"></param>
        public OrderCreatedIntegrationEvent(long orderId) => OrderId = orderId;

        /// <summary>
        /// 订单Id
        /// </summary>
        public long OrderId { get; }
    }
}
