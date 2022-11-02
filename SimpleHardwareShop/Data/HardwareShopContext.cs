using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Models;

namespace SimpleHardwareShop.Data
{

    
    public class HardwareShopContext : DbContext
    {
        
        // Constructor is 'protected'
        public HardwareShopContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, database);
        }
        //protected HardwareShopContext()
        //{
        //}
        //public static HardwareShopContext Instance()
        //{
        //    Uses lazy initialization.
        //    Note: this is not thread safe.
        //    if (_instance == null)
        //    {
        //        var folder = Environment.SpecialFolder.LocalApplicationData;
        //        var path = Environment.GetFolderPath(folder);
        //        _instance = new HardwareShopContext();

        //        _instance.DbPath = System.IO.Path.Join(path, database);
        //    }
        //    return _instance;
        //}

        static string database = "HardwareShopDatabase.db";

        public string? DbPath { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");


        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        public DbSet<Adress> Adresses { get; set; }

        public DbSet<BankCard> BankCards { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }





    }
}
