using MediatR;

namespace OrderDelayAnnouncement.Application.Commands
{
    public sealed class CreateVendorCommand : IRequest<int>
    {
        public string Name { get; set; }
    }


}
