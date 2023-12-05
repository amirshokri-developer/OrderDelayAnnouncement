using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDelayAnnouncement.Domain;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Configurations
{
    public class VendorConfig : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder
                .ToTable(nameof(Vendor))
                .HasKey(x => x.Id);
        }
    }


}
