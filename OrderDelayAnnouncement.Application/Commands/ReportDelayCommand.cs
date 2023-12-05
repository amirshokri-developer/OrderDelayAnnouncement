using MediatR;
using OrderDelayAnnouncement.Application.Models.Responses;

namespace OrderDelayAnnouncement.Application.Commands
{
    public sealed class ReportDelayCommand : IRequest<DelayResponse>
    {
        public int OrderId { get; set; }
    }
}
