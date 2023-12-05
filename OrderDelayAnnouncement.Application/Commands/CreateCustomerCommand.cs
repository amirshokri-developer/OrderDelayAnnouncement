using MediatR;

namespace OrderDelayAnnouncement.Application.Commands
{
    public sealed class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }
    }


}
