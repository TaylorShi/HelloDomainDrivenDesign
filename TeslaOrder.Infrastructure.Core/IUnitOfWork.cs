using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TeslaOrder.Infrastructure.Core
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>返回Int是指影响的数据条数</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>返回Bool是指保存是否成功</returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
