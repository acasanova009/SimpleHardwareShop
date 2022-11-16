using SimpleHardwareShop;
using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Views;
using SimpleHardwareShop.Views.Editing;

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

                        
                        customerUserController.Index(Console.ReadLine()??"");


                        break;

                    case 2:

                        try
                        {
                            //Console.WriteLine("Ingresar Id de cliente, para ver sus cotizaciones. ");
                            //var toLookUpClientId = Convert.ToInt32(Console.ReadLine());
                            
                            var cotizaciones = cotizacionDetailController.Index();

                            var ordered = cotizaciones.OrderByDescending(e => e.CustomerUserId);

                            int currentId = 0;

                            foreach (var cot in ordered)
                            {
                                
                                Console.WriteLine(cot);
                                
                            }
                            //cotizaciones.ForEach(p => Console.WriteLine(p));





                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Error, se tiene que ingresar un numero. " +ex.ToString());
                        }

                        //employeeUserController.Create(EmployeeUserCreationView.Menu());




                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Ingresar Id de cliente, para enviarle sus cotizaciones ");
                            var toLookUpClientId = Convert.ToInt32(Console.ReadLine());

                            var cotizaciones = cotizacionDetailController.Index(toLookUpClientId);
                            var nameOfText = $"Cliente:{toLookUpClientId}Cotizacion: {DateTime.Now}".Replace(" ","").Replace(":", "").Replace("-", "");
                            var finalText = "************ Cotizaciones *************";
                            foreach (var item in cotizaciones)
                            {
                                
                                finalText += "\n";
                                finalText += item.ToString();

                            }

                            Console.WriteLine("Cotizaciones al cliente "+ toLookUpClientId + "ya se envio.");
                            await CotizacionToTxt.WriteText(nameOfText, finalText);


                            cotizacionDetailController.Update(toLookUpClientId);





                        }
                        catch (Exception ex)
                        {
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
