using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Views;
using SimpleHardwareShop.Views.Creation;
using System;

public static class InteractiveManagerView
{




    public static void Menu(HardwareShopContext db, int userId)
    {
        Console.Clear();
        var employeeUserController = new EmployeeUserController(db);
        var productController = new ProductController(db);

        var cotizacionDetailController = new CotizacionDetailController(db);

        var orderDetailController = new OrderDetailController(db);

        AdressController adressController = new(db);




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
                Console.WriteLine("0. Cerrar sesión");
                Console.WriteLine("");


                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:

                        var employess = employeeUserController.Index();
                        foreach (var e in employess)
                        {
                            Console.WriteLine("***************************************************************");
                            Console.WriteLine(e);
                        }
                        


                        break;

                    case 2:

                        int newEmployeeId = employeeUserController.Create(EmployeeUserCreationView.Menu());
                        if (newEmployeeId!=0)
                        {
                            //was created
                            int newAdressId = adressController.Create(AdressCreationView.Create(newEmployeeId, true));


                            var employee = employeeUserController.Read(newEmployeeId);
                            employee.EmployeeAdressId = newAdressId;
                            employeeUserController.Update(employee);

                        }




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
                            Console.WriteLine(order.ToStringComprasAnteriores());
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
                                Console.WriteLine(order.ToStringComprasAnteriores());
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
                            Console.WriteLine(order.ToStringComprasAnteriores());
                            totalEarned += order.Count * order.Price;
                        }
                        Console.WriteLine($"*                            Tienda - Plaza de la tecnología                                 *");
                        orderDetailsByShop = orderDetailController.IndexByShop(RetailShop.PlazaDeLaTecnologia);

                        foreach (var order in orderDetailsByShop)
                        {
                            Console.WriteLine(order.ToStringComprasAnteriores());
                            totalEarned += order.Count * order.Price;
                        }


                        Console.WriteLine($"Total de ventas............................                                      ${totalEarned}");
                        Console.WriteLine($"***********************************************************************************************");
                        break;
                    case 7:

                        Console.WriteLine($"********************************************************************************************************************");
                        Console.WriteLine($"*                             REPORTE DE COTIZACIONES                                                              *");

                        totalEarned = 0.0;


                        Console.WriteLine($"*                            Tienda - Coyoacan                                                                      *");
                        var cotizaciones = cotizacionDetailController.Index();

                        foreach (var cotizacion in cotizaciones)
                        {
                            Console.WriteLine(cotizacion);
                            totalEarned += cotizacion.Count * cotizacion.Price;

                        }

                        Console.WriteLine($"Total de ventas esperadas............................                                               ${totalEarned}*");
                        Console.WriteLine($"**********************************************************************************************************************");


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
