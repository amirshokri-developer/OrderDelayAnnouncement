using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDelayAnnouncement.Domain;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {       
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable(nameof(Order)).HasKey(x => x.Id);
        }
    }


}
