using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeslaOrder.API.Application.Commands;
using TeslaOrder.API.Application.Queries;

namespace TeslaOrder.API.Controllers
{
    /// <summary>
    /// 订单服务
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMediator _mediator;

        /// <summary>
        /// 订单服务
        /// </summary>
        /// <param name="mediator"></param>
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<long> CreateOrder([FromBody]CreateOrderCommand cmd)
        {
            // 发送订单创建的命令
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="myOrderQuery"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<string>> QueryOrder([FromQuery] MyOrderQuery myOrderQuery)
        {
            return await _mediator.Send(myOrderQuery);
        }

        #region 不建议的写法
        //[HttpPost]
        //public Task<long> CreateOrder([FromBody] CreateOrderVeiwModel viewModel)
        //{
        //    var model = viewModel.ToModel();
        //    return await orderService.CreateOrder(model);
        //}


        //class OrderService : IOrderService
        //{
        //    public long CreateOrder(CreateOrderModel model)
        //    {
        //        var address = new Address("wen san lu", "hangzhou", "310000");
        //        var order = new Order("xiaohong1999", "xiaohong", 25, address);

        //        _orderRepository.Add(order);
        //        await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        //        return order.Id;
        //    }
        //}
        #endregion
    }
}
