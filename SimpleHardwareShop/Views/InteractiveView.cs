using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;



public static class InteractiveView
{

    
  

    public static void Menu(HardwareShopContext db, int userId)
	{
        
        var productController = new ProductController(db);
        var shoppingCartController = new ShoppingCartController(db);
        var applicationUserController = new ApplicationUserController(db);
        

        bool salir = false;

        while (!salir)
        {

            try
            {
                Console.WriteLine("");
                Console.WriteLine("******************************************************");
                Console.WriteLine("1. Ver productos");
                Console.WriteLine("2. Buscar productos");
                Console.WriteLine("3. Agregar/Eliminar productos del carrito");
                Console.WriteLine("4. Ver carrito");
                Console.WriteLine("5. Continuar a compra");
                Console.WriteLine("6. Continuar a cotizar");
                Console.WriteLine("7. Ver datos");
                Console.WriteLine("8. Ver compras anteriores");
                Console.WriteLine("9. Cerrar sesión");
                
                Console.WriteLine("******************************************************");
                Console.WriteLine("");


                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                         productController.Index();
                        
                        break;

                    case 2:

                        Console.WriteLine("Ingresar texto a buscar: ");

                        productController.Index(Console.ReadLine());
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Ingresar id de producto a modificar.");
                            int productId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Ingresar la cantidad final que deseas de este producto.");
                            int cantidadFinal = Convert.ToInt32(Console.ReadLine());


                            
                            shoppingCartController.Upsert(productId,userId ,cantidadFinal);

                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Entener a valid id of a product.");

                        }



                        break;
                    case 4:
                        var shoppingCarts = shoppingCartController.Index(userId);

                        var total = 0.0;
                        if(shoppingCarts.Count>0)
                        {

                            foreach (var item in shoppingCarts)
                            {

                                if(item?.Product is object)
                                total += item.Product.Price*item.Count;
                                Console.WriteLine(item);
                                

                            }
                            Console.WriteLine("-------------");
                            Console.WriteLine($"Total: ${total}");
                        }
                        else
                        {
                            Console.WriteLine("No items in cart.");
                        }



                        break;
                    case 5:

                        if(shoppingCartController.VerifyAvailableContents(userId))
                        {

                            OrderHeaderInteractiveView.Menu(db,userId);


                        }
                        else
                        {

                            Console.WriteLine("No es posible proceder a la compra, el carrito contiene mayor cantidad de la ofertada. Pero puede cotizar.");
                        }




                        break;
                    case 6:
                        break;
                    case 7:

                        applicationUserController.Read(userId);
                        break;
                    case 8:
                        
                        break;
                    case 9:
                        Console.WriteLine("Has elegido salir de la aplicación");
                        salir = true;
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
