using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Controller
{
    public class ProductController
    {

        public HardwareShopContext _db { get; set; }

        public ProductController(HardwareShopContext db)
        {
            _db=db;

        }

        public void  Index(string? textFilter = null)
        {
            //Console.WriteLine("Querying for a blog");
            if (textFilter == null)
            {

                var products =  _db.Products.Where(p =>
                p.Stock > 0).ToList();
                products.ForEach(p => Console.WriteLine(p));
            }
            else
            {
                var products = _db.Products.Where(p =>
                    //p.Price>15000
                p.Name.Contains(textFilter) ||
                p.Description.Contains(textFilter) ||
                p.Serie.Contains(textFilter) ||
                p.Inventory.Contains(textFilter) ||
                p.Price.ToString().Contains(textFilter) 

                ).ToList();
                products.ForEach(p => Console.WriteLine(p));

            }

        }



        

    }
}
