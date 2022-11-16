using Microsoft.EntityFrameworkCore.Diagnostics;
using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views.Creation;
using System;
using System.Runtime.CompilerServices;

public static class InteractiveNotRegisteredUserView
{

    static void CustomerUserRegistration(CustomerUserController customerUserController)
    {
        var customer = CustomerUserCreationView.Menu();


        if (customerUserController.Create(customer))
        {
            Console.WriteLine("Usuario creado");
        }
        else
        {
            Console.WriteLine("Usuario ya existe, porfavor ingresr con su cuenta.");

        }
    }
    public static CustomerUser? AuthenticateCustomerUser(HardwareShopContext db, CustomerUserController customerUserController)
    {
        Console.WriteLine("Ingresar correo/nombre de usuario.");
        var mailOrUserName = Console.ReadLine();
        Console.WriteLine("Ingresar contraseña");
        var password = Console.ReadLine();

        return customerUserController.AuthenticateUser(mailOrUserName ??= "", password ??= "");




    }

    //public static int CurrentOrNewUserOrLogin(ShoppingCartController shoppingCartController, ApplicationUserController applicationUserController,  CustomerUserController customerUserController, int userId, HardwareShopContext db)
    //{
    //    CustomerUser? userr = customerUserController.Read(userId);
    //    if (userr!.UserName.Equals("default01"))
    //    {
    //        try
    //        {
    //            Console.WriteLine("Ya tiene cuenta registrada? Escribir 1.");
    //            Console.WriteLine("1. Si, deseo ingresar a mi cuenta.");
    //            Console.WriteLine("2. Soy nuevo cliente, quiero registrarme.");

    //            Console.WriteLine("Elige una de las opciones");
    //            var anotherOption = Convert.ToInt32(Console.ReadLine());

    //            if (anotherOption == 1)
    //            {

    //                CustomerUser? customerUser = null;
    //                while (customerUser is not object)
    //                {
    //                    customerUser = InteractiveAuthenticationView.AuthenticateCustomerUser(db, customerUserController);
                        
                        
    //                    if(customerUser is object)
    //                    {

    //                        shoppingCartController.Update(userId, customerUser.Id);
    //                        applicationUserController.Remove(userId);
    //                        userId= customerUser.Id;
    //                    }
    //                    else
    //                    {
    //                        Console.WriteLine("Credenciales incorrectas, intentar de nuevo");
    //                        Console.WriteLine("-------------------------------------------------");
    //                        Console.WriteLine("Desea seguir intentando?");
    //                        Console.WriteLine("1. Si. deseo ingresar a mi cuenta.");
    //                        Console.WriteLine("2. No recuerdo mis datos, quiero hacer un nuevo usuario.");

    //                        Console.WriteLine("Elige una de las opciones");
    //                        var option = Convert.ToInt32(Console.ReadLine());
    //                        if (option!=1)
    //                        {
    //                            NewUserReplaceDefault(applicationUserController, userr);

    //                            break;

    //                        }

    //                    }


    //                }


    //            }
    //            else

    //            {
    //                NewUserReplaceDefault(applicationUserController, userr);
    //            }

    //        }
    //        catch (FormatException e)
    //        {
    //            Console.WriteLine(e.Message);
                
    //        }




    //    }

    //    return userId;

    //    static void NewUserReplaceDefault(ApplicationUserController applicationUserController, CustomerUser? userr)
    //    {
    //        CustomerUser? customer = null;

    //        var newUserMade = false;
    //        do
    //        {
    //            Console.WriteLine("Para continuar a la compra, tienes que registrarte");
    //            customer = CustomerUserCreationView.Menu(userr);
    //            newUserMade = applicationUserController.Update(customer);
    //            if (!newUserMade)
    //            {
    //                Console.WriteLine("Informacion del usuario ya existe.");

    //            }
    //        } while (!newUserMade);
    //    }
    //}
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

                //if(opcion>4)
                    //userId = CurrentOrNewUserOrLogin(shoppingCartController, applicationUserController, customerUserController, userId, db);

                switch (opcion)
                {
                    case 1:


                         productController.Index();
                        
                        break;

                    case 2:

                        Console.WriteLine("Ingresar texto a buscar: ");

                        productController.Index(Console.ReadLine());
                        break;

                    case 3:


                        var customerUser = AuthenticateCustomerUser(db, customerUserController);

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

                        CustomerUserRegistration(customerUserController);

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
