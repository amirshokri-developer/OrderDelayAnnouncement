﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDelayAnnouncement.Domain;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Configurations
{
    public class AgentConfig : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.ToTable(nameof(Agent)).HasKey(x => x.Id);
            builder.HasMany(c => c.DelayReports)
                .WithOne(a => a.Agent)
                .HasForeignKey(a => a.AgentId)
                .IsRequired(false);
        }
    }


}
