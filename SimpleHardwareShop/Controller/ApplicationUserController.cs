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

       

        public ApplicationUser Index(int userId)
        {

            var user = _db.ApplicationUsers
                .FirstOrDefault(m => userId == m.Id);

            return user!;
        }

        public void Remove(int oldUserId)
        {
            var temporalUser = _db.ApplicationUsers.Where(a => a.Id == oldUserId).SingleOrDefault();

            if (temporalUser != null)
            {
                _db.Remove(temporalUser);

            }
        }





    }
}
