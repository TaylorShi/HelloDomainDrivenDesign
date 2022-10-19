using MediatR;
using System.Collections.Generic;

namespace TeslaOrder.API.Application.Queries
{
    /// <summary>
    /// 订单查询命令
    /// </summary>
    public class TeslaOrderQuery : IRequest<List<string>>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
    }
}
