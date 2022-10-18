namespace TeslaOrder.API.Application.IntegrationEvents
{
    /// <summary>
    /// 订单支付成功集成事件
    /// </summary>
    public class OrderPaymentSucceededIntegrationEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="orderId"></param>
        public OrderPaymentSucceededIntegrationEvent(long orderId) => OrderId = orderId;

        /// <summary>
        /// 订单Id
        /// </summary>
        public long OrderId { get; }
    }
}
