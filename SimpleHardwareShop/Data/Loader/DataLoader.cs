using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Data.Loader
{
    public static class DataLoader
    {
        public static void Load(HardwareShopContext db)
        {
            db.Add(new Product
            {
                Name = "ALienware",
                Description = "Dungel",
                Price = 5.5,
                Stock = 5,
                Serie = "as",
                Inventory = "aaaaa",
                RetailShop = RetailShop.Galerias
            });
            db.Add(new Product
            {
                Name = "Maximus Opus",
                Description = "Dungel",
                Price = 5.5,
                Stock = 5,
                Serie = "as",
                Inventory = "aaaaa",
                RetailShop = RetailShop.PlazaDeLaComputacion
            });

            db.SaveChanges();
        }

        
    }
}
