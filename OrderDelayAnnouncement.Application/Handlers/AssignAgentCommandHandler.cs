using MediatR;
using OrderDelayAnnouncement.Application.Commands;
using OrderDelayAnnouncement.Application.Models.Responses;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public class AssignAgentCommandHandler : IRequestHandler<AssignAgentCommand, AssignAgentResponse>
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IQueueManager _queueManager;
        private readonly IDelayReportRepository _delayRepository;
        public AssignAgentCommandHandler(IQueueManager queueManager, IAgentRepository agentRepository, IDelayReportRepository delayRepository)
        {
            _queueManager = queueManager;
            _agentRepository = agentRepository;
            _delayRepository = delayRepository;
        }

        public async Task<AssignAgentResponse> Handle(AssignAgentCommand request,
            CancellationToken cancellationToken)
        {
            var agent = await _agentRepository.GetAsync(request.AgentId);

            if (agent == null)
                throw new ArgumentException("Agent Not Found");

            var checkExistance = await _delayRepository.CheckExistance(agent.Id);

            if (checkExistance)
            {
                throw new InvalidOperationException("Already Has Order On Pending");
            }

            var orderId = _queueManager.PopFromQueue();
            

            var delay = await _delayRepository.GetLast(orderId);

            delay.AssignAgent(agent.Id);

            await _delayRepository.Update(delay);

            return new AssignAgentResponse
            {
                Message = "Ok"
            };
        }
    }
}
