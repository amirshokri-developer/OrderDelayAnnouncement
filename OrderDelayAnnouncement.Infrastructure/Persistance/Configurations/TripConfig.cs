using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDelayAnnouncement.Domain;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Configurations
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder
                .ToTable(nameof(Trip))
                .HasKey(x => x.Id);
        }
    }


}
