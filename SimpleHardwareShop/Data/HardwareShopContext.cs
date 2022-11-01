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
        static string database = "HardwareShopDatabase.db";

        public string? DbPath { get; }
        public HardwareShopContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, database);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");


        public DbSet<Product> Products { get; set; }



    }
}
