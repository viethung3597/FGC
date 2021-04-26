using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGC.BI.Data
{
    public class PurchaseOrderDetail
    {
        public int PurchaseOrderID { get; set; }
        public int PurchaseOrderDetailID { get; set; }
        public DateTime DueDate { get; set; }
        public int OrderQty { get; set; }
        public int ProductID { get; set; }  
        public Decimal UnitPrice { get; set; }
        public Decimal LineTotal { get; set; }
        public Decimal ReceivedQty { get; set; }
        public Decimal RejectedQty { get; set; }
        public Decimal StockedQty { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Product Product { get; set; }
        public PurchaseOrderHeader PurchaseOrderHeader { get; set; }
    }
}
