using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGC.BI.Data
{
    public class PurchaseOrderHeader
    {
        public int PurchaseOrderHeaderID { get; set; }
        public int RevisionNumber { get; set; }
        public int Status { get; set; }
        public int EmployeeID { get; set; }
        public int VendorID { get; set; }
        public int ShipMethodID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal TaxAmt { get; set; }
        public Decimal Freight { get; set; }
        public Decimal TotalDue { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
