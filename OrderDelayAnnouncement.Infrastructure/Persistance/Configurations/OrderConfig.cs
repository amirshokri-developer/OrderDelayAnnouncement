using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDelayAnnouncement.Domain;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(v => v.Vendor)
               .WithMany(o => o.Orders)
               .HasForeignKey(e => e.VendorId)
               .IsRequired();

            builder.HasOne(c => c.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(e => e.CustomerId)
                .IsRequired();

            builder.HasMany(c => c.DelayReports)
                .WithOne(x => x.Order)
                .HasForeignKey(r => r.OrderId)
            .IsRequired();

            builder
              .HasOne(e => e.Trip)
              .WithOne(e => e.Order)
              .HasForeignKey<Trip>(e => e.OrderId)
              .IsRequired();

            builder
                .ToTable(nameof(Order)).HasKey(x => x.Id);
           
        }
    }
}
