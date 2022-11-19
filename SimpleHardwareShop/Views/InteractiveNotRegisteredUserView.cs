using Microsoft.EntityFrameworkCore.Diagnostics;
using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using SimpleHardwareShop.Views.Creation;
using System;
using System.Runtime.CompilerServices;

public static class InteractiveNotRegisteredUserView
{

    

    public static void Menu(HardwareShopContext db, int userId)
	{
        Console.Clear();
        var productController = new ProductController(db);
        var customerUserController = new CustomerUserController(db);


        bool salir = false;

        while (!salir)
        {

            try
            {
                Console.WriteLine("");
                Console.WriteLine("******************************************************");
                Console.WriteLine(" 1. Ver productos");
                Console.WriteLine(" 2. Buscar productos");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine(" Para proceder a comprar tiene que:");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine(" 3. Iniciar sesion");
                Console.WriteLine(" 4. Registrarme");
                Console.WriteLine("******************************************************");
                Console.WriteLine(" 0. Regresar");
                Console.WriteLine("******************************************************");
                Console.WriteLine("");


                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();


                switch (opcion)
                {
                    case 1:


                        var products = productController.Index();
                        products.ForEach(p => Console.WriteLine(p));

                        break;

                    case 2:

                        Console.WriteLine("Ingresar texto a buscar: ");


                        products = productController.Index(Console.ReadLine()??"");
                        products.ForEach(p => Console.WriteLine(p));
                        break;

                    case 3:


                        var customerUser = InteractiveAuthenticationView.AuthenticateCustomerUser(db, customerUserController);

                        if (customerUser is object)
                        {

                            InteractiveCustomerView.Menu(db, customerUser.Id);

                        }
                        else
                        {
                            Console.WriteLine("Correo, nombre de usuario o contaseña incorrectas");

                        }

                        break;

                    case 4:

                        InteractiveAuthenticationView.CustomerUserRegistration(customerUserController);

                        break;
                    

                    case 0:
                        //Console.Clear();
                        Console.WriteLine("Has elegido regresar");
                        
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Elige una opcion del menu");
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
