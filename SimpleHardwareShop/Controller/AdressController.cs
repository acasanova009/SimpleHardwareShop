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
    public class AdressController
    {

        public HardwareShopContext _db { get; set; }

        public AdressController(HardwareShopContext db)
        {
            _db=db;

        }
        public void Create(Adress adress)
        {
            
                _db.Adresses.Add(adress);
                _db.SaveChanges();

            
        }

        public void Index(int applicationUserId)
        {
            var adresses = _db.Adresses
                .Where(s => s.CustomerUserId == applicationUserId)
                .ToList();


            adresses.ForEach(s => Console.WriteLine(s));


        }

    }
}
