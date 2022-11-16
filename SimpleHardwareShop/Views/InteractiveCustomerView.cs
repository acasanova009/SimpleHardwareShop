using Microsoft.EntityFrameworkCore.Diagnostics;
using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views.Creation;
using SimpleHardwareShop.Views.Editing;
using System;
using System.Runtime.CompilerServices;

public static class InteractiveCustomerView
{

    
  
    //public static int CurrentOrNewUserOrLogin(ShoppingCartController shoppingCartController, ApplicationUserController applicationUserController,  CustomerUserController customerUserController, int userId, HardwareShopContext db)
    //{
    //    CustomerUser? userr = customerUserController.Read(userId);
    //    if (userr!.UserName.Equals("default01"))
    //    {
    //        try
    //        {
    //            Console.WriteLine("Ya tiene cuenta registrada? Escribir 1.");
    //            Console.WriteLine("1. Si, deseo ingresar a mi cuenta.");
    //            Console.WriteLine("2. Soy nuevo cliente, quiero registrarme.");

    //            Console.WriteLine("Elige una de las opciones");
    //            var anotherOption = Convert.ToInt32(Console.ReadLine());

    //            if (anotherOption == 1)
    //            {

    //                CustomerUser? customerUser = null;
    //                while (customerUser is not object)
    //                {
    //                    customerUser = InteractiveAuthenticationView.AuthenticateCustomerUser(db, customerUserController);
                        
                        
    //                    if(customerUser is object)
    //                    {

    //                        shoppingCartController.Update(userId, customerUser.Id);
    //                        applicationUserController.Remove(userId);
    //                        userId= customerUser.Id;
    //                    }
    //                    else
    //                    {
    //                        Console.WriteLine("Credenciales incorrectas, intentar de nuevo");
    //                        Console.WriteLine("-------------------------------------------------");
    //                        Console.WriteLine("Desea seguir intentando?");
    //                        Console.WriteLine("1. Si. deseo ingresar a mi cuenta.");
    //                        Console.WriteLine("2. No recuerdo mis datos, quiero hacer un nuevo usuario.");

    //                        Console.WriteLine("Elige una de las opciones");
    //                        var option = Convert.ToInt32(Console.ReadLine());
    //                        if (option!=1)
    //                        {
    //                            NewUserReplaceDefault(applicationUserController, userr);

    //                            break;

    //                        }

    //                    }


    //                }


    //            }
    //            else

    //            {
    //                NewUserReplaceDefault(applicationUserController, userr);
    //            }

    //        }
    //        catch (FormatException e)
    //        {
    //            Console.WriteLine(e.Message);
                
    //        }




    //    }

    //    return userId;

    //    static void NewUserReplaceDefault(ApplicationUserController applicationUserController, CustomerUser? userr)
    //    {
    //        CustomerUser? customer = null;

    //        var newUserMade = false;
    //        do
    //        {
    //            Console.WriteLine("Para continuar a la compra, tienes que registrarte");
    //            customer = CustomerUserCreationView.Menu(userr);
    //            newUserMade = applicationUserController.Update(customer);
    //            if (!newUserMade)
    //            {
    //                Console.WriteLine("Informacion del usuario ya existe.");

    //            }
    //        } while (!newUserMade);
    //    }
    //}
    public static void Menu(HardwareShopContext db, int userId)
	{
        Console.Clear();
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
                Console.WriteLine(" 1. Ver productos");
                Console.WriteLine(" 2. Buscar productos");
                Console.WriteLine(" 3. Agregar/Eliminar productos del carrito");
                Console.WriteLine(" 4. Ver carrito");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine(" 5. Continuar a compra");
                Console.WriteLine(" 6. Continuar a cotizar");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine(" 7. Ver compras anteriores");
                Console.WriteLine(" 8. Ver notificaciones");
                Console.WriteLine(" 9. Ver datos");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("10. Editar datos generales.");
                Console.WriteLine("11. Editar direcciones y tarjetas bancarias.");
                Console.WriteLine("******************************************************");
                Console.WriteLine("0. Cerrar sesión");
                Console.WriteLine("******************************************************");
                Console.WriteLine("");


                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                //if(opcion>4)
                //    userId = CurrentOrNewUserOrLogin(shoppingCartController, applicationUserController, customerUserController, userId, db);

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
                            Console.WriteLine("Entener a valid id of a product. "+ ex.ToString());

                        }



                        break;
                    case 4:
                        var shoppingCarts = shoppingCartController.Index(userId);

                        var total = 0.0;
                        if (shoppingCarts is not null && shoppingCarts.Count > 0)
                        {
                            Console.WriteLine("Carrito de compras contiene:");
                            Console.WriteLine();

                            foreach (var item in shoppingCarts)
                            {

                                if(item?.Product is not null)
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

                       


                        if (shoppingCartController.VerifyAvailableContents(userId))
                        {
                            var quiereFactura = false;
                            Console.WriteLine("Va a querer factura? Presione 1.");
                            try
                            {
                                int option = Convert.ToInt32(Console.ReadLine());
                                if(option==1)
                                    quiereFactura= true;

                            }
                            catch (Exception)
                            {

                                
                            }

                            InteractiveOrderHeaderView.Menu(db,userId,quiereFactura);


                        }
                        else
                        {
                            Console.WriteLine("No hay productos en el carro.");
                            Console.WriteLine("o el carrito contiene mayor cantidad de la ofertada.");
                        }




                        break;
                    case 6:
                       


                        var currentShoppingCartList = shoppingCartController.Index(userId);

                        if (currentShoppingCartList is not null)
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
                        //ver compras anteriores
                       
                        var orderHeaders = orderHeaderController.Index(userId);

                        foreach (var orderHeader in orderHeaders)
                        {

                            Console.WriteLine($"***************************************************************************************************************************");
                            Console.WriteLine($"*                                   COMPRA    Ticket #: {orderHeader.Id}                                                   *");

                            Console.WriteLine($"");
                            Console.WriteLine($"Fecha: {orderHeader.OrderDate}");

                           

                            if (orderHeader.OrderDetails is not null)
                            foreach (var orederDetail in orderHeader.OrderDetails)
                            {

                                Console.WriteLine(orederDetail.ToStringComprasAnteriores());
                            }

                            Console.WriteLine();
                            Console.WriteLine($"*Total de orden fue:                                                                          ${orderHeader.OrderTotal} ");

                            Console.WriteLine($"***************************************************************************************************************************");
                            
                        }



                        break;
                   


                    case 8:
                        

                        //notificaciones

                        break;
                    case 9:
                        //ver datos
                        var user = customerUserController.Read(userId);
                        Console.Write(user);

                        break;

                    case 10:
                        
                        //Generales
                        CustomerUserEditing.Menu(db, userId);

                        break;
                    case 11:
                        
                        //Bancarias
                        AdressAndBankCustomerUserEditingView.Menu(db, userId);

                        break;

                    case 0:
                        //Console.Clear();
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
