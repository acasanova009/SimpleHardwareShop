using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;



public class InteractiveView
{

    public static HardwareShopContext _db { get; set; }

    private ProductController _productController { get; set; }

    public InteractiveView(HardwareShopContext db)
    {
        _db = db;
        _productController = new ProductController(_db);
    }   

    public void UserMenu()
	{
        

        ApplicationUser user = new ApplicationUser()
        {
            Name = "Miguel",
        };


        //Let user be customer.



        bool salir = false;

        while (!salir)
        {

            try
            {

                Console.WriteLine("1. Ver productos");
                Console.WriteLine("2. Buscar productos");
                Console.WriteLine("3. Agregar producto a carrito");
                Console.WriteLine("4. Ver perfil");
                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        _productController.Index();
                        
                        break;

                    case 2:
                        Console.WriteLine("Has elegido la opción 2");
                        break;

                    case 3:
                        Console.WriteLine("Has elegido la opción 3");
                        break;
                    case 4:
                        Console.WriteLine("Has elegido salir de la aplicación");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Elige una opcion entre 1 y 4");
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }





    }
}
