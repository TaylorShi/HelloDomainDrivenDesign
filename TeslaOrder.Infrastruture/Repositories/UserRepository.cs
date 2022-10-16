using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.OrderAggregate;
using TeslaOrder.Domain.UserAggregate;
using TeslaOrder.Infrastructure.Core;

namespace TeslaOrder.Infrastruture.Repositories
{
    public class UserRepository : Repository<User, long, DomainContext>, IUserRepository
    {
        public UserRepository(DomainContext context) : base(context)
        {

        }
    }
}
