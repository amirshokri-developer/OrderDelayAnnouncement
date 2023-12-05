using MediatR;
using OrderDelayAnnouncement.Application.Commands;
using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, int>
    {
        private readonly IVendorRepository _vendorRepository;

        public CreateVendorCommandHandler(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public async Task<int> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = Vendor.Create(request.Name);
            return await _vendorRepository.InsertAsync(vendor);
        }
    }
}
