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

        public HardwareShopContext _db { get; set; }

        public CustomerUserController(HardwareShopContext db)
        {
            _db = db;

        }


        public void Index(string textFilter = "")
        {

            var customerUsers = _db.CustomerUsers
            .Where(p =>

                p.Name.Contains(textFilter) ||
                p.LastName.Contains(textFilter) ||
                p.SecondLastName.Contains(textFilter) ||
                p.UserName.Contains(textFilter) ||
                p.Email.Contains(textFilter)

                )
            .ToList();

            customerUsers.ForEach(p => Console.WriteLine(p));



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
            var bankCard = _db.BankCards.Where(a => a.CustomerUserId == userid).Where(a => a.Id == cardId).Single();

            if (user is object && bankCard is object)
            {
                user.DefaultBankCardId = cardId;

                _db.ApplicationUsers.Update(user);
                _db.SaveChanges();

            }
            else
            {
                Console.WriteLine("Id de tarjeta bancaria no existe");
            }



        }


        public void UpdateDeliveryAdress(int userid, int adressId)
        {



            var user = _db.CustomerUsers.Where(a => a.Id == userid).SingleOrDefault();
            var adress = _db.Adresses.Where(a => a.CustomerUserId == userid).Where(a => a.Id == adressId).Single();

            if (user is object && adress is object)
            {
                user.DefaultDeliveryAdressId = adressId;

                _db.ApplicationUsers.Update(user);
                _db.SaveChanges();

            }
            else
            {
                Console.WriteLine("Id de direccion no existe");
            }



        }

        public void UpdateFiscalAdress(int userid, int adressId)
        {



            var user = _db.CustomerUsers.Where(a => a.Id == userid).SingleOrDefault();
            var adress = _db.Adresses.Where(a => a.CustomerUserId == userid).Where(a => a.Id == adressId).Single();

            if (user is object && adress is object)
            {

                user.DefaultFiscalAdressId = adressId;

                _db.ApplicationUsers.Update(user);
                _db.SaveChanges();

            }
            else
            {
                Console.WriteLine("Id de direccion no existe");
            }



        }

        public bool Create(CustomerUser customer)
        {

            var users = _db.CustomerUsers.Where(a => a.UserName.Equals(customer.UserName) || a.Email.Equals(customer.Email)).ToList();

            if (users.Any())
            {
                return false;

            }
            else
            {

                _db.CustomerUsers.Add(customer);
                _db.SaveChanges();
                return true;
            }



        }

        public int CreateTemporal(CustomerUser newCustomerTemporal)
        {
            var customerAlready = _db.CustomerUsers.Where(a=>a.UserName== newCustomerTemporal.UserName).SingleOrDefault();
            var customerId = 0;
            if (customerAlready == null)
            {


                var trackingEntity = _db.CustomerUsers.Add(newCustomerTemporal);
                _db.SaveChanges();
                customerId = trackingEntity.Entity.Id;
            }
            else
            {
                customerId = customerAlready.Id;
            }
           


            return customerId;
        }



        public CustomerUser? Read(int userId)
        {

            var user = _db.CustomerUsers
                .Include(a => a.BankCards)
                .Include(a => a.Adresses)
                .FirstOrDefault(m => userId == m.Id);

            return user;


        }

    }


    
}
