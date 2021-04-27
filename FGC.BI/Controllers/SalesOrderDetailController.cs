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
    public class SalesOrderDetailController : ControllerBase
    {
        private readonly AppDataContext _context;

        public SalesOrderDetailController(AppDataContext context)
        {
            _context = context;
        }

        // GET: api/SalesOrderDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetSalesOrderDetails(DateTime startValue, DateTime endValue, int pageIndex, int pageSize)
        {
            return await _context.SalesOrderDetails
                .Select(x => new Result
                {
                    ProductName = x.Product.Name,
                    ProductID = x.ProductID,
                    Month = x.SalesOrderHeader.OrderDate.Month,
                    OrderDate = x.SalesOrderHeader.OrderDate,
                    OrderQty = x.OrderQty,
                    LineTotal = x.LineTotal

                })
                .Where(x => x.OrderDate >= startValue && x.OrderDate <= endValue)
                .OrderByDescending(x => x.LineTotal)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .ToListAsync();
        }

        // GET: api/SalesOrderDetail/5
        [HttpGet("detail/")]
        public async Task<ActionResult<IEnumerable<Result>>> GetId(DateTime startValue, DateTime endValue, int id)
        {
            return await _context.SalesOrderDetails
                .Select(x => new Result
                {
                    ProductName = x.Product.Name,
                    ProductID = x.ProductID,
                    Month = x.SalesOrderHeader.OrderDate.Month,
                    OrderDate = x.SalesOrderHeader.OrderDate,
                    OrderQty = x.OrderQty,
                    LineTotal = x.LineTotal

                })
                .Where(x => x.ProductID == id && x.OrderDate >= startValue && x.OrderDate <= endValue)
                .ToListAsync();
        }

        //[HttpGet("product/")]
        //public async Task<ActionResult<IEnumerable<Result>>> GetId(DateTime startValue, DateTime endValue, int id)
        //{

        //    return await _context.PurchaseOrderDetails
        //        .Select(x => new Result
        //        {
        //            ProductName = x.Product.Name,
        //            ProductNumber = x.Product.ProductNumber,
        //            SafetyStockLevel = x.Product.SafetyStockLevel,
        //            ReorderPoint = x.Product.ReorderPoint,
        //            ProductID = x.ProductID,
        //            PurchaseOrderDetailID = x.PurchaseOrderDetailID,
        //            PurchaseOrderID = x.PurchaseOrderID,
        //            DueDate = x.DueDate,
        //            ReceivedQty = x.ReceivedQty,
        //            Month = x.DueDate.Month
        //        })
        //        .Where(s => s.ProductID == id && s.DueDate >= startValue && s.DueDate <= endValue)
        //        .ToListAsync();
        //}

        public class Result
        {
            public string ProductName { get; set; }
            public int ProductID { get; set; }
            public DateTime OrderDate { get; set; }
            public int Month { get; set; }
            public int OrderQty { get; set; }
            public Decimal LineTotal { get; set; }

        }
    }
}
