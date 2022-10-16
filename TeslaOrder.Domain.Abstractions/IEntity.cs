using System;
using System.Collections.Generic;
using System.Text;

namespace TeslaOrder.Domain.Abstractions
{
    /// <summary>
    /// 实体接口
    /// </summary>
    public interface IEntity
    {
        object[] GetKeys();
    }

    /// <summary>
    /// 实体泛型接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; }
    }
}
