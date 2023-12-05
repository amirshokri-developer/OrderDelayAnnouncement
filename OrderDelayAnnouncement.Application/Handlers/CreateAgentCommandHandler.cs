using MediatR;
using OrderDelayAnnouncement.Application.Commands;
using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public class CreateAgentCommandHandler : IRequestHandler<CreateAgentCommand, int>
    {

        private readonly IAgentRepository _agentRepository;

        public CreateAgentCommandHandler(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<int> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
        {
            var agent = Agent.Create(request.Name);
            return await _agentRepository.InsertAsync(agent);
        }
    }
}
