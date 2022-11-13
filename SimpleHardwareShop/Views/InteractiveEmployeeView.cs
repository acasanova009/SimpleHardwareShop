using SimpleHardwareShop;
using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Views;

public static class InteractiveEmployeeView
{




    public static void Menu(HardwareShopContext db, int userId)
    {
        //var employeeUserController = new EmployeeUserController(db);
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
                Console.WriteLine("*******************************************************");
                Console.WriteLine("0. Cerrar sesión");
                Console.WriteLine("");


                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        Console.WriteLine("Ingresar algun dato del cliente para buscar. ");

                        
                        customerUserController.Index(Console.ReadLine()??"");


                        break;

                    case 2:

                        try
                        {
                            Console.WriteLine("Ingresar Id de cliente, para ver sus cotizaciones. ");
                            var toLookUpClientId = Convert.ToInt32(Console.ReadLine());
                            
                            var cotizaciones = cotizacionDetailController.Index(toLookUpClientId);
                            cotizaciones.ForEach(p => Console.WriteLine(p));





                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Error, se tiene que ingresar un numero");
                        }

                        //employeeUserController.Create(EmployeeUserCreationView.Menu());




                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Ingresar Id de cliente, para ver sus cotizaciones. ");
                            var toLookUpClientId = Convert.ToInt32(Console.ReadLine());

                            var cotizaciones = cotizacionDetailController.Index(toLookUpClientId);
                            var finalText = "";
                            foreach (var item in cotizaciones)
                            {
                                finalText += item.ToString();

                            }

                            CotizacionToTxt.WriteText(finalText);





                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error, se tiene que ingresar un numero");
                        }



                        break;
                    case 4:

                        //Console.WriteLine($"*********************************************************************************************");
                        //Console.WriteLine($"*                             REPORTE DE VENTAS GENERAL                                     *");
                        //var orderDetails = orderDetailController.Index();
                        //var totalEarned = 0.0;

                        //foreach (var order in orderDetails)
                        //{
                        //    Console.WriteLine(order);
                        //    totalEarned += order.Count * order.Price;

                        //}
                        //Console.WriteLine($"Total de ventas............................                                    ${totalEarned}");
                        //Console.WriteLine($"***********************************************************************************************");


                        break;
                    case 5:

                        //Console.WriteLine($"*********************************************************************************************");
                        //Console.WriteLine($"*                             REPORTE DE VENTAS POR PRODUCTO                                *");

                        //totalEarned = 0.0;
                        //for (int productId = 1; productId <= 16; productId++)
                        //{

                        //    Console.WriteLine($"*                            ProductoId {productId}                                     *");
                        //    var orderDetailsByProduct = orderDetailController.IndexByProduct(productId);

                        //    foreach (var order in orderDetailsByProduct)
                        //    {
                        //        Console.WriteLine(order);
                        //        totalEarned += order.Count * order.Price;

                        //    }
                        //}

                        //Console.WriteLine($"Total de ventas............................                                    ${totalEarned}");
                        //Console.WriteLine($"***********************************************************************************************");




                        break;
                    case 6:


                        //Console.WriteLine($"*********************************************************************************************");
                        //Console.WriteLine($"*                             REPORTE DE VENTAS POR SUCURSAL                                *");

                        //totalEarned = 0.0;


                        //Console.WriteLine($"*                            Tienda - Coyoacan                                               *");
                        //var orderDetailsByShop = orderDetailController.IndexByShop(RetailShop.Coyoacan);

                        //foreach (var order in orderDetailsByShop)
                        //{
                        //    Console.WriteLine(order);
                        //    totalEarned += order.Count * order.Price;

                        //}


                        //Console.WriteLine($"Total de ventas............................                                    ${totalEarned}");
                        //Console.WriteLine($"***********************************************************************************************");
                        break;
                    case 7:

                        //var user = applicationUserController.Read(userId);
                        //Console.Write(user);


                        break;
                    case 8:

                        ////orderHeaderController.Index(userId);

                        //Console.WriteLine("Has elegido cerrar sesion");
                        salir = true;
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
