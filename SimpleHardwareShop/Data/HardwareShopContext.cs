using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SimpleHardwareShop.Models;

/* 
  Equipo Individual
*/
/*

  Codigo por: Gonzalez Casanova Gallegos Renato Alfonso
  

  Fecha de cración: 19/Nov/2022

  Comentario General: Este programa simula una tienda de productos de hardware, que se conecta directamente con bases de datos.

*/


namespace SimpleHardwareShop.Data
{

    
    public class HardwareShopContext : DbContext
    {
        
        // Constructor is 'protected'
        public HardwareShopContext()
        {

            //var newPaht = Path.GetPathRoot


            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, database);

           
        }

        private static string database = "HardwareShopDatabase.db";

        public string? DbPath { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            //SQLite
            //options.UseSqlite($"Data Source={DbPath}");

            options.UseSqlite($"Data Source=HardwareShopDatabase.db");

            //MSSQL
            //options.UseSqlServer("Server = LAISSEZFAIRE; Database = HardwareShopDatabase; Trusted_Connection = True;TrustServerCertificate=True;");



            //AZURE
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "hardwaresqlserver.database.windows.net";
            builder.UserID = "azureuser";
            builder.Password = "@AlfaTao1234@";
            builder.InitialCatalog = "HardwareShopDatabase";
            //options.UseSqlServer(builder.ConnectionString);



        }


        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<CustomerUser> CustomerUsers { get; set; }
        public DbSet<EmployeeUser> EmployeeUsers { get; set; }


        public DbSet<Adress> Adresses { get; set; }

        public DbSet<BankCard> BankCards { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }

        public DbSet<CotizacionDetail> CotizacionDetails { get; set; }




    }
}
