using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDelayAnnouncement.Domain;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Configurations
{
    public class DelayReportConfig : IEntityTypeConfiguration<DelayReport>
    {
        public void Configure(EntityTypeBuilder<DelayReport> builder)
        {
            builder.ToTable(nameof(DelayReport)).HasKey(x => x.Id);
        }
    }


}
