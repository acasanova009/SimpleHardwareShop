using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using SimpleHardwareShop.Views.Creation;
using System;

namespace SimpleHardwareShop.Views.Editing
{
    public static class EmployeeUserEditingView
    {

        //public static HardwareShopContext _db { get; set; }
        //private ProductController _productController { get; set; }
        //private ShoppingCartController _shoppingCartController { get; set; }
        //private ApplicationUserController applicationUserController { get; set; }

        //private ApplicationUser? _activeUser { get; set; }
        //public ApplicationUserInteractiveView(HardwareShopContext db)
        //{
        //}

        //private ShoppingCartController _shoppingCartController { get; set; }


        public static void Menu(HardwareShopContext db, int userId)
        {
            Console.Clear();

            var employeeUserController = new EmployeeUserController(db);

            var applicationUser = employeeUserController.Index(userId);

            AdressController adressController = new(db);


            bool salir = false;

            while (!salir)
            {

                try
                {

                    Console.WriteLine("");
                    Console.WriteLine("******************************************************");
                    Console.WriteLine("1. Modificar Nombre");
                    Console.WriteLine("2. Modificar Apellido Paterno");
                    Console.WriteLine("3. Modificar Apellido Materno");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("4. Modificar NombreDeUsuario");
                    Console.WriteLine("5. Modificar Correo electronico");
                    Console.WriteLine("6. Modificar Contraseña");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("7. Agregar Direccion y RFC");
                    Console.WriteLine("******************************************************");
                    Console.WriteLine("0. Regresar");
                    Console.WriteLine("******************************************************");
                    Console.WriteLine("");


                    Console.WriteLine("Elige una de las opciones");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:

                            Console.WriteLine("Ingresa nuevo nombre");
                            applicationUser.Name = Console.ReadLine() ?? "DefaultName";
                            employeeUserController.Update(applicationUser);





                            break;

                        case 2:


                            Console.WriteLine("Ingresa nuevo apellido paterno");
                            applicationUser.LastName = Console.ReadLine() ?? "Default apellido paterno";
                            employeeUserController.Update(applicationUser);




                            break;

                        case 3:

                            Console.WriteLine("Ingresa nuevo apellido materno");
                            applicationUser.SecondLastName = Console.ReadLine() ?? "Default apellido materno";
                            employeeUserController.Update(applicationUser);


                            break;
                        case 4:

                            Console.WriteLine("Ingresa nuevo nombre de usuario.");
                            applicationUser.UserName = Console.ReadLine() ?? "Default apellido materno";
                            if (!employeeUserController.UpdateUpdateUserName(applicationUser))
                            {
                                Console.WriteLine("Nombre de usuario ya existe, intentar otra vez.");

                            }



                            break;
                        case 5:

                            Console.WriteLine("Ingresa nuevo correo electronico.");
                            applicationUser.Email = Console.ReadLine() ?? "DefaultCorreo@corre.com";
                            employeeUserController.Update(applicationUser);

                            break;
                        case 6:


                            Console.WriteLine("Ingresa nuevo contraseña");
                            var newPass = Console.ReadLine() ?? "12345678";
                            if (newPass.Length >= 8)
                            {
                                applicationUser.Password = newPass;
                                employeeUserController.Update(applicationUser);
                            }
                            else
                            {
                                Console.WriteLine("La contraseña es muy pequeña");
                            }

                            break;
                        case 7:


                            int newAdressId = adressController.Create(AdressCreationView.Create(userId, true));


                            var employee = employeeUserController.Index(userId);
                            employee.EmployeeAdressId = newAdressId;
                            employeeUserController.Update(employee);

                            break;

                        case 0:
                            Console.Clear();
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
}