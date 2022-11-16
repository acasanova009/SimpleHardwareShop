using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views.Creation;

public static class InteractiveAuthenticationView
{

    public static CustomerUser? AuthenticateCustomerUser(HardwareShopContext db, CustomerUserController customerUserController)
    {
        Console.WriteLine("Ingresar correo/nombre de usuario.");
        var mailOrUserName = Console.ReadLine();
        Console.WriteLine("Ingresar contraseña");
        var password = Console.ReadLine();

        return  customerUserController.AuthenticateUser(mailOrUserName ??= "", password ??= "");


       

    }

    
    public static void Menu(HardwareShopContext db)
    {
        var applicationUserController = new ApplicationUserController(db);
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
                Console.WriteLine("0. Salir");
                Console.WriteLine("******************************************************");

                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("Loading...");
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
                            Console.WriteLine("Correo, nombre de usuario o contaseña incorrectas");

                        }

                        break;

                    case 3:

                        CustomerUserRegistration(customerUserController);

                        break;

                    case 4:


                        Console.WriteLine("Ingresar correo/nombre de usuario.");
                        var mailOrUserName = Console.ReadLine();
                        Console.WriteLine("Ingresar contraseña");
                         var password = Console.ReadLine();


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
                    
                   
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Has elegido salir de la aplicacion");
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
    }
}
