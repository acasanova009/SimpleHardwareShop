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
        public void Index(int userId)
        {
            var  includableQueryable = _db.OrderHeaders
                                .Where(e => e.CustomerUserId == userId)
                                .Include(e => e.OrderDetails);
            var orders = includableQueryable
                    .ThenInclude(m => m.Product).AsNoTracking().ToList();
            //;

            //    _context.Students
            //.Include(s => s.Enrollments)
            //    .ThenInclude(e => e.Course)
            //.AsNoTracking()
            //.FirstOrDefaultAsync(m => m.ID == id);
            //OrderBy(e => e.Id == userId).

            orders.ForEach(p => Console.WriteLine(p));

            //Console.WriteLine(orders);



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

                

            }

            

        }
        public  void  Save()
        {
             _db.SaveChanges();
        }



        

    }
}
