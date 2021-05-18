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
    public class ShippersController : ControllerBase
    {
        [HttpGet()]
        public List<Shipper> GetAllCustomers()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Shippers.ToList();
            }
        }

        [HttpGet("companyname")]
        public List<Shipper> SearchByType(string shipper)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                List<Shipper> result = context.Shippers.ToList().Where(p => p.CompanyName.ToLower() == shipper.ToLower()).ToList();
                return result;
            }
        }

        [HttpPost("AddShipper")]
        public Shipper AddShipper(string companyName, string phone)
        {
            Shipper shipper = new Shipper();

            shipper.CompanyName = companyName;
            shipper.Phone = phone;

            using (NorthwindContext context = new NorthwindContext())
            {
                context.Shippers.Add(shipper);
                context.SaveChanges();
            }
            return shipper;
        }

        [HttpDelete("delete/{id}")]
        public string DeleteShipper(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                Shipper shipper = context.Shippers.ToList().Find(s => s.ShipperId == id);
                if (shipper == null)
                {
                    return "that shipper was not found";
                }
                else
                {
                    context.Shippers.Remove(shipper);
                    context.SaveChanges();
                    return "that shipper was deleted";
                }
                
            }
        }

    }
}
