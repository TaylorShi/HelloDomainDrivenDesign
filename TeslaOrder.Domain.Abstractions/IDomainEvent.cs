﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeslaOrder.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
    }
}
