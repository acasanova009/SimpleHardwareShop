using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using System;



public static class InteractiveManagerView
{

    
  

    public static void Menu(HardwareShopContext db, int userId)
	{
        var employeeUserController = new EmployeeUserController(db);
        var productController = new ProductController(db);

        //var quotationController = new QuotationController(db);





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
                        //var shoppingCarts = shoppingCartController.Index(userId);

                        //var total = 0.0;
                        //if(shoppingCarts.Count>0)
                        //{

                        //    foreach (var item in shoppingCarts)
                        //    {

                        //        if(item?.Product is object)
                        //        total += item.Product.Price*item.Count;
                        //        Console.WriteLine(item);
                                

                        //    }
                        //    Console.WriteLine("-------------");
                        //    Console.WriteLine($"Total: ${total}");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("No items in cart.");
                        //}



                        break;
                    case 5:

                        //if(shoppingCartController.VerifyAvailableContents(userId))
                        //{

                        //    OrderHeaderInteractiveView.Menu(db,userId);


                        //}
                        //else
                        //{

                        //    Console.WriteLine("No es posible proceder a la compra, el carrito contiene mayor cantidad de la ofertada. Pero puede cotizar.");
                        //}




                        break;
                    case 6:
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
