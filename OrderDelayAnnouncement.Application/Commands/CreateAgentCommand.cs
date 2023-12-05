using MediatR;

namespace OrderDelayAnnouncement.Application.Commands
{
    public sealed class CreateAgentCommand : IRequest<int>
    {
        public string Name { get; set; }
    }


}
