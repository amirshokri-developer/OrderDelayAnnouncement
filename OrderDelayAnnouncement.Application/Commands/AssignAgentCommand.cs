using MediatR;
using OrderDelayAnnouncement.Application.Models.Responses;

namespace OrderDelayAnnouncement.Application.Commands
{
    public sealed class AssignAgentCommand : IRequest<AssignAgentResponse>
    {        
        public int AgentId { get; set;}
    }

}
