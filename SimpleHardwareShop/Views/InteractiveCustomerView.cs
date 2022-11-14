using Microsoft.EntityFrameworkCore.Diagnostics;
using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views.Creation;
using System;



public static class InteractiveCustomerView
{

    
  
    public static int CurrentOrNewUserOrLogin(ShoppingCartController shoppingCartController, ApplicationUserController applicationUserController,  CustomerUserController customerUserController, int userId, HardwareShopContext db)
    {
        CustomerUser? userr = customerUserController.Read(userId);
        if (userr!.UserName == null)
        {
            try
            {
                Console.WriteLine("Ya tiene cuenta registrada? Escribir 1.");
                Console.WriteLine("1. Si, deseo ingresar a mi cuenta.");
                Console.WriteLine("2. Soy nuevo cliente, quiero registrarme.");

                Console.WriteLine("Elige una de las opciones");
                var anotherOption = Convert.ToInt32(Console.ReadLine());

                if (anotherOption == 1)
                {

                    CustomerUser? customerUser = null;
                    while (customerUser is not object)
                    {
                        customerUser = InteractiveAuthenticationView.AuthenticateCustomerUser(db, customerUserController);
                        
                        
                        if(customerUser is object)
                        {

                            shoppingCartController.Update(userId, customerUser.Id);
                            applicationUserController.Remove(userId);
                            userId= customerUser.Id;
                        }
                        else
                        {
                            Console.WriteLine("Credenciales incorrectas, intentar de nuevo");
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("Desea seguir intentando?");
                            Console.WriteLine("1. Si. deseo ingresar a mi cuenta.");
                            Console.WriteLine("2. No recuerdo mis datos, quiero hacer un nuevo usuario.");

                            Console.WriteLine("Elige una de las opciones");
                            var option = Convert.ToInt32(Console.ReadLine());
                            if (option!=1)
                            {

                                //CHICLE
                                Console.WriteLine("Para continuar a la compra, tienes que registrarte");
                                var customer = CustomerUserCreationView.Menu(userr);
                                applicationUserController.Update(customer);
                                break;

                            }

                        }


                    }


                }
                else

                {
                    Console.WriteLine("Para continuar a la compra, tienes que registrarte");
                    var customer = CustomerUserCreationView.Menu(userr);
                    applicationUserController.Update(customer);
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                
            }




        }

        return userId;
    }
    public static void Menu(HardwareShopContext db, int userId)
	{
        
        var productController = new ProductController(db);
        var shoppingCartController = new ShoppingCartController(db);
        var applicationUserController = new ApplicationUserController(db);
        var customerUserController = new CustomerUserController(db);

        var orderHeaderController = new OrderHeaderController(db);

        var cotizacionDetailController = new CotizacionDetailController(db);


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
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("5. Continuar a compra");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("6. Continuar a cotizar");
                Console.WriteLine("7. Ver datos");
                Console.WriteLine("8. Ver compras anteriores");
                Console.WriteLine("9. Ver notificaciones");
                Console.WriteLine("******************************************************");
                Console.WriteLine("0. Cerrar sesión");
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
                            Console.WriteLine("Carrito de compras contiene:");
                            Console.WriteLine();

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
                            Console.WriteLine("No hay artículos en el carrito.");
                        }



                        break;
                    case 5:

                        userId = CurrentOrNewUserOrLogin(shoppingCartController, applicationUserController, customerUserController, userId, db);


                        if (shoppingCartController.VerifyAvailableContents(userId))
                        {

                            InteractiveOrderHeaderView.Menu(db,userId);


                        }
                        else
                        {
                            Console.WriteLine("No hay productos en el carro.");
                            Console.WriteLine("o el carrito contiene mayor cantidad de la ofertada.");
                        }




                        break;
                    case 6:
                        userId = CurrentOrNewUserOrLogin(shoppingCartController, applicationUserController, customerUserController, userId, db);


                        var currentShoppingCartList = shoppingCartController.Index(userId);

                        if (currentShoppingCartList is object)
                            foreach (var item in currentShoppingCartList)
                            {
                                cotizacionDetailController.CreateDetails(CotizacionDetail.Create(userId, item.Product!.Id, item.Count, item.Product.Price));
                                


                            }
                        cotizacionDetailController.Save();


                        Console.WriteLine($"***************************************************************************************************************************");
                        Console.WriteLine($"*                                   COTIZACION SOLICITADA                                                                 *");
                        Console.WriteLine($"*                                  Solicitud en proceso de envio.                                                         *");
                        Console.WriteLine($"***************************************************************************************************************************");
                        

                        break;
                    case 7:
                        userId = CurrentOrNewUserOrLogin(shoppingCartController, applicationUserController, customerUserController, userId, db);

                        var user = customerUserController.Read(userId);
                        Console.Write(user);

                        break;
                    case 8:
                         userId = CurrentOrNewUserOrLogin(shoppingCartController, applicationUserController, customerUserController, userId, db);


                        var orderHeaders = orderHeaderController.Index(userId);

                        orderHeaders.ForEach(orderH => Console.WriteLine(orderH));

                        break;
                    case 9:
                        userId = CurrentOrNewUserOrLogin(shoppingCartController, applicationUserController, customerUserController, userId, db);
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
