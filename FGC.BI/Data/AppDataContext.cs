using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGC.BI.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PurchaseOrderDetail>(e =>
            {
                e.ToTable("PurchaseOrderDetail", "Purchasing");
                e.HasOne(x => x.PurchaseOrderHeader).WithMany().HasForeignKey(x => x.PurchaseOrderID);
            });

            builder.Entity<Product>(e =>
            {
                e.ToTable("Product", "Production");
            });

            builder.Entity<PurchaseOrderHeader>(e =>
            {
                e.ToTable("PurchaseOrderHeader", "Purchasing");
            });
        }
    }
}
