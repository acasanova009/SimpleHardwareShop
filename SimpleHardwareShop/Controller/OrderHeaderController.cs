using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Controller
{
    public class OrderHeaderController
    {

        public HardwareShopContext _db { get; set; }

        public OrderHeaderController(HardwareShopContext db)
        {
            _db=db;

        }

        public OrderHeader Create(OrderHeader oh)
        {


        }

        public void CreateDetails(OrderDetail od)
        {

        }



        

    }
}
