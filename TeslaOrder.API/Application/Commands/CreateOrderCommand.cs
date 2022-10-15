using MediatR;

namespace TeslaOrder.API.Application.Commands
{
    public class CreateOrderCommand : IRequest<long>
    {

        //ublic CreateOrderCommand() { }
        public CreateOrderCommand(int itemCount)
        {
            ItemCount = itemCount;
        }

        public long ItemCount { get; private set; }
    }
}
