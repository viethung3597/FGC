using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGC.BI.Data
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string MakeFlag { get; set; }
        public string FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public Int16 SafetyStockLevel { get; set; }
        public Int16 ReorderPoint { get; set; }
        public Decimal StandardCost { get; set; }
        public Decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public Decimal Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int ProductSubcategoryID { get; set; }
        public int ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime SellEndDate { get; set; }
        public DateTime DiscontinuedDate { get; set; }
        public string rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
