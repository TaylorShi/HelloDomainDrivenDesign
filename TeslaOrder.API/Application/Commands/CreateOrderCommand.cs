using MediatR;

namespace TeslaOrder.API.Application.Commands
{
    /// <summary>
    /// 创建订单命令
    /// </summary>
    public class CreateOrderCommand : IRequest<long>
    {
        /// <summary>
        /// 商品数量
        /// </summary>
        public int ItemCount { get; private set; }

        /// <summary>
        /// 创建订单命令
        /// </summary>
        public CreateOrderCommand()
        {

        }

        /// <summary>
        /// 创建订单命令
        /// </summary>
        /// <param name="itemCount"></param>
        public CreateOrderCommand(int itemCount)
        {
            ItemCount = itemCount;
        }
    }
}
