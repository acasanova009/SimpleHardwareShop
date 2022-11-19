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
    public class CustomerUserController
    {

        private HardwareShopContext Db { get; set; }

        public CustomerUserController(HardwareShopContext db)
        {
            Db = db;

        }

        //public CustomerUser Index(int userId)
        //{

        //    var user = Db.CustomerUsers
        //        .FirstOrDefault(m => userId == m.Id);

        //    return user!;
        //}


        public List<CustomerUser> Index(string textFilter = "")
        {

            var customerUsers = Db.CustomerUsers
            .Where(p =>

                p.Name.Contains(textFilter) ||
                p.LastName.Contains(textFilter) ||
                p.SecondLastName.Contains(textFilter) ||
                p.UserName.Contains(textFilter) ||
                p.Email.Contains(textFilter)

                )
            .ToList();

            return customerUsers;
            



        }


        public CustomerUser? AuthenticateUser(string emialOrUsername, string password)
        {
            var users = Db.CustomerUsers
                .Where(a => a.UserName.Equals(emialOrUsername) || a.Email.Equals(emialOrUsername))
                .Where(a => a.Password.Equals(password))

                ;


            if (!users.Any())
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



            var user = Db.CustomerUsers.Where(a => a.Id == userid).SingleOrDefault();
            var bankCard = Db.BankCards.Where(a => a.CustomerUserId == userid).Where(a => a.Id == cardId).Single();

            if (user is not null && bankCard is not null)
            {
                user.DefaultBankCardId = cardId;

                Db.ApplicationUsers.Update(user);
                Db.SaveChanges();

            }
            else
            {
                Console.WriteLine("Id de tarjeta bancaria no existe");
            }



        }


        public void UpdateDeliveryAdress(int userid, int adressId)
        {



            var user = Db.CustomerUsers.Where(a => a.Id == userid).SingleOrDefault();
            var adress = Db.Adresses.Where(a => a.CustomerUserId == userid).Where(a => a.Id == adressId).Single();

            if (user is not null && adress is not null)
            {
                user.DefaultDeliveryAdressId = adressId;

                Db.ApplicationUsers.Update(user);
                Db.SaveChanges();

            }
            else
            {
                Console.WriteLine("Id de direccion no existe");
            }



        }

        public void UpdateFiscalAdress(int userid, int adressId)
        {



            var user = Db.CustomerUsers.Where(a => a.Id == userid).SingleOrDefault();
            var adress = Db.Adresses.Where(a => a.CustomerUserId == userid).Where(a => a.Id == adressId).Single();

            if (user is not null && adress is not null)
            {

                user.DefaultFiscalAdressId = adressId;

                Db.ApplicationUsers.Update(user);
                Db.SaveChanges();

            }
            else
            {
                Console.WriteLine("Id de direccion no existe");
            }



        }

        public bool UpdateUserName(CustomerUser application)
        {

            //var currentUsername = _db.CustomerUsers.Where(a => a.UserName.Equals(application.UserName)).SingleOrDefault();
            var users = Db.CustomerUsers.Where(a => a.UserName.Equals(application.UserName)).ToList();


            if (users.Any())
            {
                return false;

            }
            else
            {
                Db.CustomerUsers.Update(application);
                Db.SaveChanges();
                return true;
            }
        }

        public bool Update(CustomerUser application)
        {
             Db.CustomerUsers.Update(application);
                Db.SaveChanges();
                return true;
        }

        public bool Create(CustomerUser customer)
        {

            var users = Db.CustomerUsers.Where(a => a.UserName.Equals(customer.UserName) || a.Email.Equals(customer.Email)).ToList();

            if (users.Any())
            {
                return false;

            }
            else
            {

                Db.CustomerUsers.Add(customer);
                Db.SaveChanges();
                return true;
            }



        }

        //public int CreateTemporal(CustomerUser newCustomerTemporal)
        //{
        //    var customerAlready = Db.CustomerUsers.Where(a=>a.UserName== newCustomerTemporal.UserName).SingleOrDefault();
        //    var customerId = 0;
        //    if (customerAlready == null)
        //    {


        //        var trackingEntity = Db.CustomerUsers.Add(newCustomerTemporal);
        //        Db.SaveChanges();
        //        customerId = trackingEntity.Entity.Id;
        //    }
        //    else
        //    {
        //        customerId = customerAlready.Id;
        //    }
           


        //    return customerId;
        //}



        public CustomerUser Read(int userId)
        {

            var user = Db.CustomerUsers
                .Include(a => a.BankCards)
                .Include(a => a.Adresses)
                .FirstOrDefault(m => userId == m.Id);

            return user;


        }

    }


    
}
