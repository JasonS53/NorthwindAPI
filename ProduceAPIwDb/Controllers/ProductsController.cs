using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProduceAPIwDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet()]
        public List<Product> GetAllProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }

        [HttpGet("ProductName")]
        public List<Product> SearchByType(string productName)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                List<Product> result = context.Products.ToList().Where(p => p.ProductName.ToLower() == productName.ToLower()).ToList();
                return result;
            }
        }


    }
}
