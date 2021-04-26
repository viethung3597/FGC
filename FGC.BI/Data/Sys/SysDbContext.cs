using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGC.BI.Data.Sys
{
    public class SysDbContext : DbContext
    {
        public SysDbContext(DbContextOptions<SysDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(e =>
            {
                e.Property(e => e.UserName).HasConversion(
                        v => v,
                        v => v.Trim());
                e.Property(e => e.HashedPassword).HasConversion(
                    v => v,
                    v => v.Trim());
                e.Property(e => e.Key).HasConversion(
                    v => v,
                    v => v.Trim());
            });

        }
    }
}
