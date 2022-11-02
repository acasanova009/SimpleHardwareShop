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
    public class BankCardController
    {

        public HardwareShopContext _db { get; set; }

        public BankCardController(HardwareShopContext db)
        {
            _db=db;

        }
        public void Create(BankCard bankCard)
        {
            
                _db.BankCards.Add(bankCard);
                _db.SaveChanges();

            
        }

        public void Index(int applicationUserId)
        {
            var adresses = _db.BankCards
                .Where(s => s.ApplicationUserId == applicationUserId)
                .ToList();


            adresses.ForEach(s => Console.WriteLine(s));


        }

        

    }
}
