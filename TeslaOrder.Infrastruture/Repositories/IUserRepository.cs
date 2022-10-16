using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.OrderAggregate;
using TeslaOrder.Domain.UserAggregate;
using TeslaOrder.Infrastructure.Core;

namespace TeslaOrder.Infrastruture.Repositories
{
    public interface IUserRepository : IRepository<User, long>
    {

    }
}
