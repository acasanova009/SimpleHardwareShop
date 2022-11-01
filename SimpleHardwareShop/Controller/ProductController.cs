using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Controller
{
    public class ProductController
    {
        //public static List<Product> GetAll()
        //{
        //    List<Product> products = new List<Product>();
        //    products.Add(new Product()
        //    { 
        //        Id=1,
        //        Name="Sam",
        //        Description ="Myfav"
        //    });
        //    products.Add(new Product()
        //    {
        //        Id = 2,
        //        Name = "Another Sam",
        //        Description = "Me Seonc Fav"
        //    });
        //    return products;
        //}

        public HardwareShopContext _db { get; set; }

        public ProductController(HardwareShopContext db)
        {
            _db=db;

        }

        public void Index()
        {
            Console.WriteLine("Querying for a blog");
            var products = _db.Products.ToList();

            Console.WriteLine(products);


        }

        //List<Product> _products;

        //public void Menu()
        //{

        //    bool salir = false;
        //    while (!salir)
        //    {

        //        try
        //        {

        //            Console.WriteLine("1. Ver productos.");
        //            Console.WriteLine("2. Opción 2");
        //            Console.WriteLine("3. Opción 3");
        //            Console.WriteLine("4. Salir");
        //            Console.WriteLine("Elige una de las opciones");
        //            int opcion = Convert.ToInt32(Console.ReadLine());

        //            switch (opcion)
        //            {
        //                case 1:

        //                    this.Index();
        //                    break;

        //                case 2:
        //                    Console.WriteLine("Has elegido la opción 2");
        //                    break;

        //                case 3:
        //                    Console.WriteLine("Has elegido la opción 3");
        //                    break;
        //                case 4:
        //                    Console.WriteLine("Has elegido salir de la aplicación");
        //                    salir = true;
        //                    break;
        //                default:
        //                    Console.WriteLine("Elige una opcion entre 1 y 4");
        //                    break;
        //            }

        //        }
        //        catch (FormatException e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //}
        //public void Index()
        //{
        //    //Console.WriteLine("\nProducts: ");
        //    //for (int i = 0; i < _products.Count; i++)
        //    //{
        //    //    Console.WriteLine(_products[i]);
                

        //    //}
        //    foreach (var product in _products)
        //    {
        //        Console.WriteLine(product);
        //    }


        //}

    }
}
