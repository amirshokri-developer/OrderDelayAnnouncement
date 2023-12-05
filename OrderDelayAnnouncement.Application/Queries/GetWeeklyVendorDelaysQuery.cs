using MediatR;
using OrderDelayAnnouncement.Application.Models.Responses;

namespace OrderDelayAnnouncement.Application.Queries
{
    public sealed class GetWeeklyVendorDelaysQuery : IRequest<GetWeeklyVendorDelaysResponse>
    {
        
    }
}
