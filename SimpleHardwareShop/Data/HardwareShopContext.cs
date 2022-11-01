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
        static HardwareShopContext _instance;
        // Constructor is 'protected'
        protected HardwareShopContext()
        {
        }
        public static HardwareShopContext Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);
                _instance = new HardwareShopContext();

                _instance.DbPath = System.IO.Path.Join(path, database);
            }
            return _instance;
        }
    
        static string database = "HardwareShopDatabase.db";

        public string? DbPath { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");


        public DbSet<Product> Products { get; set; }



    }
}
