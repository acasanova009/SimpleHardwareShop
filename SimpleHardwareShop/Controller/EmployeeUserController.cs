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
    public class EmployeeUserController
    {

        public HardwareShopContext _db { get; set; }

        public EmployeeUserController(HardwareShopContext db)
        {
            _db=db;

        }

        public EmployeeUser? AuthenticateUser(string emialOrUsername, string password)
        {
            var users = _db.EmployeeUsers
                .Where(a => a.UserName.Equals(emialOrUsername) || a.Email.Equals(emialOrUsername))
                .Where(a => a.Password.Equals(password));


            if (users.Count() > 1)
            {
                Console.WriteLine("Database Error, multiple users");
                return null;
            }
            else if (users.Count() == 0)
            {

                return null;
            }
            else
            {
                return users.Single();
            }
        }

        public void Index()
        {
            
            {
                var employee = _db.EmployeeUsers.ToList();
                employee.ForEach(p => Console.WriteLine(p));

            }

        }

        public bool Create(EmployeeUser employee)
        {
            
            var users =  _db.EmployeeUsers.Where(a => a.UserName.Equals(employee.UserName)|| a.Email.Equals(employee.Email)).ToList();

            if (users.Any())
            {
                return false;

            }
            else
            {

                _db.ApplicationUsers.Add(employee);
                _db.SaveChanges();
                return true;
            }



        }
        public EmployeeUser?  Read(int userId)
        {

            var user = _db.EmployeeUsers
                //.Include(a => a.BankCards)
                //.Include(a => a.Adresses)
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
