using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using System;



public static class AuthenticationView
{

    
    
    //private ShoppingCartController _shoppingCartController { get; set; }

   

    public static void Menu(HardwareShopContext db)
	{
        var applicationUserController = new ApplicationUserController(db);

        bool salir = false;

        while (!salir)
        {

            try
            {

                Console.WriteLine("");
                Console.WriteLine("******************************************************");

                Console.WriteLine("1. Iniciar sesion");
                Console.WriteLine("2. Registrarme");
                
                Console.WriteLine("******************************************************");

                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        Console.WriteLine("Ingresar correo/nombre de usuario.");
                        var mailOrUserName = Console.ReadLine();
                        Console.WriteLine("Ingresar contraseña");
                        var password = Console.ReadLine();

                        var applicationUser = applicationUserController.AuthenticateUser(mailOrUserName ??= "", password ??= "");

                        //ApplicationUser applicationUser = user;

                        if (applicationUser is object)
                        {

                            
                            switch (applicationUser.UserType)
                            {
                                case UserType.Application:
                                    
                                    InteractiveView.Menu(db,applicationUser.Id);

                                    break;
                                case UserType.Employee:
                                    break;
                                case UserType.Manager:
                                    break;
                                default:
                                    Console.WriteLine("User type not recognized");
                                    break;
                            }
                            //if(applicationUser.GetType().IsAssignableFrom(typeof(ApplicationUser))){
                            //    Console.WriteLine("Normal user");
                            
                            //}
                            //else if (applicationUser.GetType().IsAssignableFrom(typeof(ApplicationUser)))
                            //{

                            //    Console.WriteLine("Αdmin/Employe");
                            //}
                        }
                        else
                        {
                            Console.WriteLine("Correo, nombre de usuario o contaseña incorrectas");

                        }

                        break;

                    case 2:

                        var application = ApplicationUserCreationView.Menu();


                        if (applicationUserController.Create(application))
                        {
                            Console.WriteLine("Usuario creado");
                        }
                        else
                        {
                            Console.WriteLine("Usuario ya existe");

                        }




                        //Console.WriteLine("Ingresar texto a buscar: ");

                        //_productController.Index(Console.ReadLine());
                        break;

                    case 3:
                        //try
                        //{
                        //    Console.WriteLine("Ingresar id de producto a modificar.");
                        //    int productId = Convert.ToInt32(Console.ReadLine());

                        //    Console.WriteLine("Ingresar la cantidad final que deseas de este producto.");
                        //    int cantidadFinal = Convert.ToInt32(Console.ReadLine());


                        //    _shoppingCartController.Upsert(productId, user.Id,cantidadFinal);

                        //}
                        //catch(Exception ex)
                        //{
                        //    Console.WriteLine("Entener a valid id of a product.");

                        //}



                        break;
                    case 4:
                          //_shoppingCartController.Index(user.Id);


                        break;
                    case 5:
                        Console.WriteLine("Has elegido salir de la aplicación");
                        
                        break;
                    case 6:
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
