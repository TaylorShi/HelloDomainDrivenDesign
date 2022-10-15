using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.Abstractions;

namespace TeslaOrder.Domain.UserAggregate
{
    public class User : Entity<long>, IAggregateRoot
    {

    }
}
