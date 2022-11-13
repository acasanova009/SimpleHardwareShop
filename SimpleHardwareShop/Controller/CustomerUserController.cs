﻿using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Controller
{
    public class CustomerUserController
    {

        public HardwareShopContext _db { get; set; }

        public CustomerUserController(HardwareShopContext db)
        {
            _db=db;

        }


        public CustomerUser? AuthenticateUser(string emialOrUsername, string password)
        {
            var users = _db.CustomerUsers
                .Where(a => a.UserName.Equals(emialOrUsername) || a.Email.Equals(emialOrUsername))
                .Where(a => a.Password.Equals(password))

                ;


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


        public void UpdateDefaultCard(int userid, int cardId)
        {



            var user = _db.CustomerUsers.Where(a => a.Id == userid).SingleOrDefault();

            if (user is object)
            {
                user.DefaultBankCardId = cardId;

                _db.ApplicationUsers.Update(user);
                _db.SaveChanges();

            }
            else
            {
                Console.WriteLine("Error in database");
            }



        }


        public void UpdateDeliveryAdress(int userid, int adressId)
        {



            var user = _db.CustomerUsers.Where(a => a.Id == userid).SingleOrDefault();

            if(user is object)
            {
                user.DefaultDeliveryAdressId = adressId;

                _db.ApplicationUsers.Update(user);
                _db.SaveChanges();

            }
            else
            {
                Console.WriteLine("Error in database");
            }
            


        }

        public void UpdateFiscalAdress(int userid, int adressId)
        {



            var user = _db.CustomerUsers.Where(a => a.Id == userid).SingleOrDefault();

            if (user is object)
            {
                user.DefaultFiscalAdressId = adressId;

                _db.ApplicationUsers.Update(user);
                _db.SaveChanges();

            }
            else
            {
                Console.WriteLine("Error in database");
            }



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
