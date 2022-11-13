using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Views;



public static class AuthenticationView
{



    //private ShoppingCartController _shoppingCartController { get; set; }



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

                Console.WriteLine("1. Iniciar sesion");
                Console.WriteLine("2. Registrarme");

                Console.WriteLine("******************************************************");
                Console.WriteLine("3. (Empleados) Iniciar sesion");

                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        Console.WriteLine("Ingresar correo/nombre de usuario.");
                        var mailOrUserName = Console.ReadLine();
                        Console.WriteLine("Ingresar contraseña");
                        var password = Console.ReadLine();

                        var customerUser = customerUserController.AuthenticateUser(mailOrUserName ??= "", password ??= "");


                        if (customerUser is object)
                        {

                            InteractiveView.Menu(db, customerUser.Id);

                        }
                        else
                        {
                            Console.WriteLine("Correo, nombre de usuario o contaseña incorrectas");

                        }

                        break;

                    case 2:

                        var application = CustomerUserCreationView.Menu();


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


                        Console.WriteLine("Ingresar correo/nombre de usuario.");
                         mailOrUserName = Console.ReadLine();
                        Console.WriteLine("Ingresar contraseña");
                         password = Console.ReadLine();


                        var employeeUser = employeeUserController.AuthenticateUser(mailOrUserName ??= "", password ??= "");

                        if (employeeUser is object)
                        {

                            switch (employeeUser.EmployeeType)
                            {
                                case EmployeeType.Manager:


                                    InteractiveManagerView.Menu(db, employeeUser.Id);
                                    break;
                                case EmployeeType.Employee:


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
