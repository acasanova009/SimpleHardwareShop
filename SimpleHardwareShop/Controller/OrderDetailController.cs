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
    public class OrderDetailController
    {

        public HardwareShopContext _db { get; set; }

        public OrderDetailController(HardwareShopContext db)
        {
            _db=db;

        }
        public List<OrderDetail> Index()
        {
            return _db.OrderDetails.ToList();





        }

        public List<OrderDetail> IndexByProduct(int productId)
        {
            return _db.OrderDetails.Where(a=>a.ProductId==productId).ToList();


        }

        public List<OrderDetail> IndexByShop(RetailShop retailShop)
        {
            return _db.OrderDetails
                    .Include(a=>a.Product)
                    .Where(a=>a.Product.RetailShop==retailShop)
                    .ToList();


        }




    }
}
