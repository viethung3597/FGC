using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FGC.BI.Data;

namespace FGC.BI.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(e =>
            {
                e.ToTable("Product", "Production");
            });

            builder.Entity<PurchaseOrderDetail>(e =>
            {
                e.ToTable("PurchaseOrderDetail", "Purchasing");
                e.HasOne(x => x.PurchaseOrderHeader).WithMany().HasForeignKey(x => x.PurchaseOrderID);
            });

            builder.Entity<PurchaseOrderHeader>(e =>
            {
                e.ToTable("PurchaseOrderHeader", "Purchasing");
            });

            builder.Entity<SalesOrderHeader>(e =>
            {
                e.ToTable("SalesOrderHeader", "Sales").HasKey(x => x.SalesOrderID);
            });

            builder.Entity<SalesOrderDetail>(e =>
            {
                e.ToTable("SalesOrderDetail", "Sales");
                e.HasOne(x => x.SalesOrderHeader).WithMany(x => x.SalesOrderDetails).HasForeignKey(x => x.SalesOrderID);
                e.HasOne(x => x.Product).WithMany(x => x.SalesOrderDetails).HasForeignKey(x => x.ProductID);
            });



        }

    }
}
