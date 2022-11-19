using SimpleHardwareShop;
using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using SimpleHardwareShop.Views.Editing;


/* 
  Equipo Individual
*/
/*

  Codigo por: Gonzalez Casanova Gallegos Renato Alfonso
  

  Fecha de cración: 19/Nov/2022

  Comentario General: Este programa simula una tienda de productos de hardware, que se conecta directamente con bases de datos.

*/

/// <summary>Class <c>InteractiveEmployeeView</c> Clase estática que representa una vista de para el empleado</summary>
public static class InteractiveEmployeeView
{




    public static async void Menu(HardwareShopContext db, int userId)
    {

        Console.Clear();
        var employeeUserController = new EmployeeUserController(db);
        //var productController = new ProductController(db);

        //var quotationController = new QuotationController(db);

        //var orderDetailController = new OrderDetailController(db);

        var customerUserController = new CustomerUserController(db);

        var cotizacionDetailController = new CotizacionDetailController(db);

        





        bool salir = false;

        while (!salir)
        {

            try
            {
                Console.WriteLine("");
                Console.WriteLine("*****************    MENU Empleado   ******************");
                Console.WriteLine("1. Buscar cliente");
                Console.WriteLine("2. Ver cotizaciones");
                Console.WriteLine("3. Enviar cotizacion");
                Console.WriteLine("*******************************************************");
                Console.WriteLine("4. Actualizar datos personales");
                Console.WriteLine("5. Ver datos personales");
                Console.WriteLine("*******************************************************");
                Console.WriteLine("0. Cerrar sesión");
                Console.WriteLine("");


                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                switch (opcion)
                {
                    case 1:

                        Console.WriteLine("Ingresar algun dato del cliente para buscar. ");

                        Console.WriteLine("\nLoading...\n");

                        var customerUsers = customerUserController.Index(Console.ReadLine()??"");
                        customerUsers.ForEach(p => Console.WriteLine(p));


                        break;

                    case 2:

                        try
                        {

                            Console.WriteLine("\nLoading...\n");

                            var cotizaciones = cotizacionDetailController.Index();

                            if (!cotizaciones.Any())
                            {
                                Console.WriteLine("No hay cotizacion en espera de envio");
                                
                            }
                            else
                            {

                                var ordered = cotizaciones.OrderByDescending(e => e.CustomerUserId);

                                int currentId = 0;

                                foreach (var cot in ordered)
                                {
                                
                                    Console.WriteLine(cot);
                                
                                }

                            }



                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Error, se tiene que ingresar un numero. " +ex.ToString());
                        }




                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Ingresar Id de cliente, para enviarle sus cotizaciones ");
                            var toLookUpClientId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\nLoading...\n");

                            var cotizaciones = cotizacionDetailController.Index(toLookUpClientId);
                            var nameOfText = $"Cliente:{toLookUpClientId}Cotizacion: {DateTime.Now}".Replace(" ","").Replace(":", "").Replace("-", "");
                            var finalText = "************ Cotizaciones *************";
                            double total = 0.0;
                            foreach (var item in cotizaciones)
                            {
                                
                                finalText += "\n";
                                finalText += item.ToString() + "........." + item.Count * item.Price;
                                total += item.Count * item.Price;

                            }

                            finalText += $"\n Costo total...............................{total}";
                            Console.WriteLine("Cotizaciones al cliente "+ toLookUpClientId + " se acaba de enviar.");
                            _ = CotizacionToTxt.WriteText(nameOfText, finalText);

                           

                            cotizacionDetailController.Update(toLookUpClientId);





                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error 5");
                            Console.WriteLine("Error, se tiene que ingresar un numero. " + ex.ToString());
                        }



                        break;
                    case 4:
                        EmployeeUserEditingView.Menu(db, userId);

                        break;

                    case 5:
                        var employee = employeeUserController.Read(userId);
                        Console.WriteLine(employee);
                        break;

                    case 0:
                        Console.WriteLine("Has elegido regresar");
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
}
