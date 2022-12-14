using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views.Creation;

namespace SimpleHardwareShop.Views
{
    /* 
  Equipo Individual
*/
    /*

      Codigo por: Gonzalez Casanova Gallegos Renato Alfonso


      Fecha de cración: 19/Nov/2022

      Comentario General: Este programa simula una tienda de productos de hardware, que se conecta directamente con bases de datos.

    */

    /// <summary>Class <c>InteractiveAuthenticationView</c> Clase estática que representa una vista para inciciar sesión con el tipo de usuario deseado.</summary>
    public static class InteractiveAuthenticationView
    {




        public static void Menu(HardwareShopContext db)
        {
            //var applicationUserController = new ApplicationUserController(db);
            var customerUserController = new CustomerUserController(db);
            var employeeUserController = new EmployeeUserController(db);


            bool salir = false;

            while (!salir)
            {

                try
                {

                    Console.WriteLine("");
                    Console.WriteLine("******************************************************");


                    Console.WriteLine("1. Ver tienda");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("2. Iniciar sesion");
                    Console.WriteLine("3. Registrarme");

                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("4. (Empleados) Iniciar sesion");

                    Console.WriteLine("******************************************************");
                    Console.WriteLine("10. Salir");
                    Console.WriteLine("******************************************************");

                    Console.WriteLine("Elige una de las opciones");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    
                    switch (opcion)
                    {
                        case 1:

                            
                            InteractiveNotRegisteredUserView.Menu(db, -1);

                            break;
                        case 2:


                            
                            var customerUser = AuthenticateCustomerUser(db, customerUserController);

                            if (customerUser is object)
                            {
                                InteractiveCustomerView.Menu(db, customerUser.Id);

                            }
                            else
                            {
                                Console.WriteLine("nombre de usuario o contaseña incorrectas");

                            }

                            break;

                        case 3:

                            CustomerUserRegistration(customerUserController);

                            break;

                        case 4:


                            Console.WriteLine("Ingresar nombre de usuario.");
                            var mailOrUserName = Console.ReadLine();
                            Console.WriteLine("Ingresar contraseña");
                            var password = Console.ReadLine();


                            Console.WriteLine("\nLoading...\n");
                            var employeeUser = employeeUserController.AuthenticateUser(mailOrUserName ??= "", password ??= "");

                            if (employeeUser is object)
                            {

                                switch (employeeUser.EmployeeType)
                                {
                                    case EmployeeType.Manager:

                                        
                                        InteractiveManagerView.Menu(db, employeeUser.Id);
                                        break;
                                    case EmployeeType.Employee:

                                        InteractiveEmployeeView.Menu(db, employeeUser.Id);


                                        break;
                                    case EmployeeType.CFO:
                                        break;
                                    default:
                                        Console.WriteLine("User type not recognized");
                                        break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Employee identification failed");
                            }

                            break;


                        case 10:
                            
                            Console.WriteLine("Has elegido salir de la aplicacion");
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Elige una opcion del menu");
                            Console.WriteLine("Error 001");
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public static CustomerUser? AuthenticateCustomerUser(HardwareShopContext db, CustomerUserController customerUserController)
        {
            Console.WriteLine("Ingresar nombre de usuario.");
            var mailOrUserName = Console.ReadLine();
            Console.WriteLine("Ingresar contraseña");
            var password = Console.ReadLine();

            Console.WriteLine("\nLoading...\n");

            return customerUserController.AuthenticateUser(mailOrUserName ??= "", password ??= "");




        }
        public static void CustomerUserRegistration(CustomerUserController customerUserController)
        {
            var customer = CustomerUserCreationView.Menu();


            if (customerUserController.Create(customer))
            {
                Console.WriteLine("Usuario creado");
            }
            else
            {
                Console.WriteLine("Error 008");
                Console.WriteLine("Usuario ya existe, porfavor ingresr con su cuenta.");

            }
        }
    }
}