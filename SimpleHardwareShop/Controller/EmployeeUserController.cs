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
                .Where(a => a.UserName.Equals(emialOrUsername))
                .Where(a => a.Password.Equals(password));


            if (users.Count() > 1)
            {
                Console.WriteLine("Database Error, multiple users");
                return null;
            }
            else if (!users.Any())
            {

                return null;
            }
            else
            {
                return users.Single();
            }
        }

        //public EmployeeUser Index(int userId)
        //{

        //    var user = _db.EmployeeUsers
        //        .FirstOrDefault(m => userId == m.Id);

        //    return user!;
        //}
        public List<EmployeeUser> Index()
        {
            
            
                return _db.EmployeeUsers.Include(a=>a.Adresses).ToList();
                

            

        }

        public int Create(EmployeeUser employee)
        {


            var users =  _db.EmployeeUsers.Where(a => a.UserName.Equals(employee.UserName)|| a.Email.Equals(employee.Email)).ToList();

            if (users.Any())
            {
                return 0;

            }
            else
            {

                var trackingEntity = _db.ApplicationUsers.Add(employee);
                _db.SaveChanges();
                return trackingEntity.Entity.Id;
            }



        }
        public EmployeeUser  Read(int userId)
        {

            var user = _db.EmployeeUsers
                .Include(a => a.Adresses)
                .FirstOrDefault(m=>userId==m.Id);

            return user;

        }

      

        public bool Update(EmployeeUser application)
        {

            
                _db.ApplicationUsers.Update(application);
                _db.SaveChanges();
                return true;
            
        }

        public bool UpdateUserName(EmployeeUser application)
        {

            var users = _db.ApplicationUsers.Where(a => a.UserName.Equals(application.UserName)).ToList();

            if (users.Any())
            {
                return false;

            }
            else
            {
                _db.ApplicationUsers.Update(application);
                _db.SaveChanges();
                return true;
            }
        }





    }
}
