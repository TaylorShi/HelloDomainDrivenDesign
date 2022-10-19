using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace TeslaOrder.API.Application.Queries
{
    /// <summary>
    /// 订单查询命令处理程序
    /// </summary>
    public class TeslaOrderQueryHandler : IRequestHandler<TeslaOrderQuery, List<string>>
    {
        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<string>> Handle(TeslaOrderQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<string>() { DateTime.Now.ToString() });
        }
    }
}
