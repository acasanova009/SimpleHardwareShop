using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using System;
using System.Xml.Schema;

public static class InteractiveManagerView
{

    
  

    public static void Menu(HardwareShopContext db, int userId)
	{
        var employeeUserController = new EmployeeUserController(db);
        var productController = new ProductController(db);

        //var quotationController = new QuotationController(db);

        var orderDetailController = new OrderDetailController(db);





        bool salir = false;

        while (!salir)
        {

            try
            {
                Console.WriteLine("");
                Console.WriteLine("*****************    MENU GERENTE   ******************");
                Console.WriteLine("1. Ver Empleados");
                Console.WriteLine("2. Agregar Empleados");
                Console.WriteLine("3. Actualizar Stock");
                Console.WriteLine("***************** REPORTES DE VENTA ******************");
                Console.WriteLine("4. Reporte - General (Todas las ventas");
                Console.WriteLine("5. Reporte - Por producto");
                Console.WriteLine("6. Reporte - Por sucursal");
                Console.WriteLine("7. Reporte - Cotización");
                
                
                Console.WriteLine("******************************************************");
                Console.WriteLine("8. Cerrar sesión");
                Console.WriteLine("");


                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        employeeUserController.Index();


                        break;

                    case 2:

                        employeeUserController.Create(EmployeeUserCreationView.Menu());

                        

                        
                        break;

                    case 3:
                        productController.Update();



                        break;
                    case 4:

                        Console.WriteLine($"*********************************************************************************************");
                        Console.WriteLine($"*                             REPORTE DE VENTAS GENERAL                                     *");
                        var orderDetails = orderDetailController.Index();
                        var totalEarned = 0.0;

                        foreach (var order in orderDetails)
                        {
                            Console.WriteLine(order);
                            totalEarned += order.Count * order.Price;

                        }
                        Console.WriteLine($"Total de ventas............................                                    ${totalEarned}");
                        Console.WriteLine($"***********************************************************************************************");


                        break;
                    case 5:

                        Console.WriteLine($"*********************************************************************************************");
                        Console.WriteLine($"*                             REPORTE DE VENTAS POR PRODUCTO                                *");

                        totalEarned = 0.0;
                        for (int productId = 1; productId <= 16; productId++)
                        {

                            Console.WriteLine($"*                            ProductoId {productId}                                     *");
                            var orderDetailsByProduct = orderDetailController.IndexByProduct(productId);

                            foreach (var order in orderDetailsByProduct)
                            {
                                Console.WriteLine(order);
                                totalEarned += order.Count * order.Price;

                            }
                        }

                        Console.WriteLine($"Total de ventas............................                                    ${totalEarned}");
                        Console.WriteLine($"***********************************************************************************************");




                        break;
                    case 6:


                        Console.WriteLine($"*********************************************************************************************");
                        Console.WriteLine($"*                             REPORTE DE VENTAS POR SUCURSAL                                *");

                        totalEarned = 0.0;
                        

                        Console.WriteLine($"*                            Tienda - Coyoacan                                               *");
                        var orderDetailsByShop = orderDetailController.IndexByShop(RetailShop.Coyoacan);

                        foreach (var order in orderDetailsByShop)
                        {
                            Console.WriteLine(order);
                            totalEarned += order.Count * order.Price;

                        }
                        

                        Console.WriteLine($"Total de ventas............................                                    ${totalEarned}");
                        Console.WriteLine($"***********************************************************************************************");
                        break;
                    case 7:

                        //var user = applicationUserController.Read(userId);
                        //Console.Write(user);


                        break;
                    case 8:

                        //orderHeaderController.Index(userId);

                        Console.WriteLine("Has elegido cerrar sesion");
                        salir = true;
                        break;
                        
                    case 9:
                        break;
                    default:
                        Console.WriteLine("Elige una opcion entre 1 y 9");
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
