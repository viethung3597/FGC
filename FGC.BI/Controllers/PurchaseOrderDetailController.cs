using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FGC.BI.Data;

namespace FGC.BI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderDetailController : ControllerBase
    {
        private readonly AppDataContext _context;

        public PurchaseOrderDetailController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetData(DateTime startValue, DateTime endValue, int pageIndex, int pageSize)
        {
            //return await _context.PurchaseOrderDetails.ToListAsync();
            return await _context.PurchaseOrderDetails
                //.Include(a => a.product)
                //.Include(a => a.orderHeader)
                .Select(x => new Result
                {
                    ProductName = x.Product.Name,
                    ProductNumber = x.Product.ProductNumber,
                    SafetyStockLevel = x.Product.SafetyStockLevel,
                    ReorderPoint = x.Product.ReorderPoint,
                    ProductID = x.ProductID,
                    PurchaseOrderDetailID = x.PurchaseOrderDetailID,
                    PurchaseOrderID = x.PurchaseOrderID,
                    DueDate = x.DueDate,
                    ReceivedQty = x.ReceivedQty,
                    Month = x.DueDate.Month
                })
                .Where(s => s.DueDate >= startValue && s.DueDate <= endValue)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .ToListAsync();
        }

        [HttpGet("product/")]
        public async Task<ActionResult<IEnumerable<Result>>> GetId(DateTime startValue, DateTime endValue, int id)
        {

            return await _context.PurchaseOrderDetails
                .Select(x => new Result
                {
                    ProductName = x.Product.Name,
                    ProductNumber = x.Product.ProductNumber,
                    SafetyStockLevel = x.Product.SafetyStockLevel,
                    ReorderPoint = x.Product.ReorderPoint,
                    ProductID = x.ProductID,
                    PurchaseOrderDetailID = x.PurchaseOrderDetailID,
                    PurchaseOrderID = x.PurchaseOrderID,
                    DueDate = x.DueDate,
                    ReceivedQty = x.ReceivedQty,
                    Month = x.DueDate.Month
                })
                .Where(s => s.ProductID == id && s.DueDate >= startValue && s.DueDate <= endValue)
                .ToListAsync();
        }
    }



    public class Result
    {
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public int SafetyStockLevel { get; set; }
        public int ReorderPoint { get; set; }
        public int ProductID { get; set; }
        public int PurchaseOrderDetailID { get; set; }
        public int PurchaseOrderID { get; set; }
        public DateTime DueDate { get; set; }
        public Decimal ReceivedQty { get; set; }
        public int Month { get; set; }
    }

}
