using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TeslaOrder.Domain.OrderAggregate;
using TeslaOrder.Infrastruture.Repositories;

namespace TeslaOrder.API.Application.Commands
{
    /// <summary>
    /// 创建订单命令处理方法
    /// </summary>
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {
        /// <summary>
        /// 订单仓储
        /// </summary>
        IOrderRepository _orderRepository;

        /// <summary>
        /// 创建订单命令处理方法
        /// </summary>
        /// <param name="orderRepository"></param>
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// 处理方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var address = new Address("沙头街道", "深圳", "518048");
            var order = new Order("414675056", "taylorshi", request.ItemCount, address);

            _orderRepository.Add(order);
             await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return order.Id;
        }
    }
}
