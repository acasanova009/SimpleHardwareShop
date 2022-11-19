using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleHardwareShop.Controller
{
    public class OrderHeaderController
    {

        public HardwareShopContext _db { get; set; }

        public OrderHeaderController(HardwareShopContext db)
        {
            _db=db;

        }
        public List<OrderHeader> Index(int userId)
        {
            var includableQueryable = _db.OrderHeaders
                                .Where(e => e.CustomerUserId == userId)
                                .Include(e => e.OrderDetails);
                                

            var orders = includableQueryable
                    .ThenInclude(m => m.Product).AsNoTracking().ToList();
           

            return orders;


        }

        public int Create(OrderHeader oh)
        {
            
            var trackingEntity= _db.OrderHeaders.Add(oh);

            _db.SaveChanges();

            return trackingEntity.Entity.Id;  
            
        }

        public void CreateDetails(OrderDetail od)
        {

            if (od != null)
            {
                _db.OrderDetails.Add(od);
                _db.SaveChanges();


            }

            

        }
       


        

    }
}
