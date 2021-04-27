using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FGC.BI.Data
{
    public class SalesOrderHeader
    {
        public int SalesOrderID { get; set; }
        public Byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipDate { get; set; }
        public Byte Status { get; set; }
        public Boolean OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public int SalesPersonID { get; set; }
        public int TerritoryID { get; set; }
        public int BillToAddressID { get; set; }
        public int ShipToAddressID { get; set; }
        public int ShipMethodID { get; set; }
        public int CreditCardID { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public int CurrencyRateID { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal TaxAmt { get; set; }
        public Decimal Freight { get; set; }
        public Decimal TotalDue { get; set; }
        public string Comment { get; set; }
        //public string rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
