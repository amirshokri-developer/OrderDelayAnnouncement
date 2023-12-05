using Microsoft.EntityFrameworkCore;
using OrderDelayAnnouncement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelayAnnouncement.Infrastructure.Persistance
{
    public class OMSContext : DbContext
    {
        public OMSContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<DelayReport> DelayReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
