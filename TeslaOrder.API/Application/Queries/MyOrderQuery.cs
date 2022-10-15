using MediatR;
using System.Collections.Generic;

namespace TeslaOrder.API.Application.Queries
{
    public class MyOrderQuery : IRequest<List<string>>
    {
        public string UserName { get; set; }
    }
}
