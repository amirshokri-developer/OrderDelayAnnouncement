using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDelayAnnouncement.Domain;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer)).HasKey(x => x.Id);
        }
    }


}
