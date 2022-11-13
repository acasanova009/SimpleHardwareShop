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
    public class ApplicationUserController
    {

        public HardwareShopContext _db { get; set; }

        public ApplicationUserController(HardwareShopContext db)
        {
            _db=db;

        }

      
        public bool Create(ApplicationUser application)
        {
            
            var users =  _db.ApplicationUsers.Where(a => a.UserName.Equals(application.UserName)|| a.Email.Equals(application.Email)).ToList();

            if (users.Any())
            {
                return false;

            }
            else
            {

                _db.ApplicationUsers.Add(application);
                _db.SaveChanges();
                return true;
            }







                //var shoppingCarts = _db.ShoppingCarts
                //.Where(s => s.ApplicationUserId == applicationUserId)
                //.Include(p => p.Product)
                //.ToList();

        }
        public CustomerUser?  Read(int userId)
        {

            var user = _db.CustomerUsers
                .Include(a => a.BankCards)
                .Include(a => a.Adresses)
                .FirstOrDefault(m=>userId==m.Id);

            return user;
            
            //Console.Write(user);
            
            //Console.WriteLine("Querying for a blog");
            //if (textFilter == null)
            //{

            //    var products = _db.Products.Where(p =>
            //    p.Stock > 0).ToList();
            //    products.ForEach(p => Console.WriteLine(p));
            //}
            //else
            //{
            //    var products = _db.Products.Where(p =>
            //        p.Price > 15000
            //    p.Name.Contains(textFilter) ||
            //    p.Description.Contains(textFilter) ||
            //    p.Serie.Contains(textFilter) ||
            //    p.Inventory.Contains(textFilter) ||
            //    p.Price.ToString().Contains(textFilter)

            //    ).ToList();
            //    products.ForEach(p => Console.WriteLine(p));

            //}

        }



        

    }
}
