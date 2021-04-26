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
    public class ProductController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ProductController(AppDataContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            
            _context.Products
                .Where(x => x.ProductID == 1)
                .Select(x => new
                {
                    x.ProductNumber,
                    PurchaseOrderDetails = x.PurchaseOrderDetails.Select(a => new { 
                        a.DueDate,
                        a.ReceivedQty
                    }).ToList()
                })
                .ToList();

            return await _context.Products.ToListAsync();
        }



    }
}
