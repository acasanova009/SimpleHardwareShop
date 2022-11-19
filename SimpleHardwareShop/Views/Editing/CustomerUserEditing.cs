using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using System;

namespace SimpleHardwareShop.Views.Editing
{
    public static class CustomerUserEditing
    {
        public static void Menu(HardwareShopContext db, int userId)
        {
            Console.Clear();
            var customerUserController = new CustomerUserController(db);


            var customerUser = customerUserController.Read(userId);


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

                    Console.WriteLine("******************************************************");
                    Console.WriteLine("0. Regresar");
                    Console.WriteLine("******************************************************");
                    Console.WriteLine("");


                    Console.WriteLine("Elige una de las opciones");
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:

                            Console.WriteLine("Ingresa nuevo nombre");
                            customerUser.Name = Console.ReadLine() ?? "DefaultName";
                            customerUserController.Update(customerUser);





                            break;

                        case 2:


                            Console.WriteLine("Ingresa nuevo apellido paterno");
                            customerUser.LastName = Console.ReadLine() ?? "Default apellido paterno";
                            customerUserController.Update(customerUser);




                            break;

                        case 3:

                            Console.WriteLine("Ingresa nuevo apellido materno");
                            customerUser.SecondLastName = Console.ReadLine() ?? "Default apellido materno";
                            customerUserController.Update(customerUser);


                            break;
                        case 4:

                            Console.WriteLine("Ingresa nuevo nombre de usuario.");
                            customerUser.UserName = Console.ReadLine() ?? "Default apellido materno";
                            if (!customerUserController.UpdateUserName(customerUser))
                            {
                                Console.WriteLine("Nombre de usuario ya existe, intentar otra vez.");

                            }



                            break;
                        case 5:

                            Console.WriteLine("Ingresa nuevo correo electronico.");
                            customerUser.Email = Console.ReadLine() ?? "DefaultCorreo@corre.com";
                            customerUserController.Update(customerUser);

                            break;
                        case 6:


                            Console.WriteLine("Ingresa nuevo contraseña");
                            var newPass = Console.ReadLine() ?? "12345678";
                            if (newPass.Length >= 8)
                            {
                                customerUser.Password = newPass;
                                customerUserController.Update(customerUser);
                            }
                            else
                            {
                                Console.WriteLine("La contraseña es muy pequeña");
                            }

                            break;

                        case 0:
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