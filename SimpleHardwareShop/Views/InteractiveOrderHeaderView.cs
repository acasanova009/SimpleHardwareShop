using Microsoft.EntityFrameworkCore.Query.Internal;
using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using SimpleHardwareShop.Views.Creation;
//using System;

/* 
  Equipo Individual
*/
/*

  Codigo por: Gonzalez Casanova Gallegos Renato Alfonso
  

  Fecha de cración: 19/Nov/2022

  Comentario General: Este programa simula una tienda de productos de hardware, que se conecta directamente con bases de datos.

*/

/// <summary>Class <c>InteractiveOrderHeaderView</c> Clase estática que representa una vista de confirmación de compras</summary>
public static class InteractiveOrderHeaderView
{

   


    public static void Menu(HardwareShopContext db,int userId, bool quiereFactura)
	{
       

        Console.Clear();


        var productController = new ProductController(db);
        var customerUserController = new CustomerUserController(db);
        var orderHeaderController = new OrderHeaderController(db);
        var shoppingCartController = new ShoppingCartController(db);


        bool userWantsFacturar = quiereFactura;

        var customerUser = customerUserController.Read(userId);

        bool salir = false;

        while (!salir)
        {

            try
            {
                Console.WriteLine("");
                Console.WriteLine("******************************************************");
                Console.WriteLine("1. Definir direccion y metodo de pago.");
                Console.WriteLine("2. Revisar detalles de compra.");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("3. Requiero facturar: "+userWantsFacturar);
                Console.WriteLine("4. Confirmar compra.");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("0. Regresar");
                Console.WriteLine("******************************************************");

                Console.WriteLine("");


                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:


                        Console.Clear();

                        AdressAndBankCustomerUserEditingView.Menu(db, userId);

                        


                        break;


                    case 2:

                        Console.WriteLine("\nLoading...\n");

                        Console.WriteLine($"+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine($"+                                   Resumen de la compra                                                                  +");
                        Console.WriteLine($"+-------------------------------------------------------------------------------------------------------------------------+");
                        Console.WriteLine($"+                                   Informacion Cliente                                                                   +");

                        //var customerUser = customerUserController.Read(userId);


                        Console.WriteLine(customerUser?.ToStringResumenCompras());
                        Console.WriteLine($"+-------------------------------------------------------------------------------------------------------------------------+");
                        Console.WriteLine($"+                                  Ariticulos por comprar                                                                 +");

                        var shoppingCart = shoppingCartController.Index(userId);
                        double total = 0.0;

                        if(shoppingCart is not null)
                        foreach (var item in shoppingCart)
                        {

                            Console.WriteLine(item);
                            total += item.Count * item.Product!.Price;
                        }

                        Console.WriteLine();
                        Console.WriteLine($"+Precio TOTAL es:                                                                                              ${total}   +");

                        Console.WriteLine($"+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");








                        break;
                    case 3:
                        var quiereFacturar = 0;
                        Console.WriteLine("Desea facturar?");
                        Console.WriteLine("1. Sí desea factura");
                        Console.WriteLine("2. No ");
                        try
                        {
                            quiereFacturar = Convert.ToInt32(Console.ReadLine());
                            if (quiereFacturar ==1)
                            {
                                userWantsFacturar = true;

                            }
                            else
                            {
                                userWantsFacturar   = false;
                            }

                        }
                        catch (Exception)
                        {
                            userWantsFacturar = false;
                            Console.WriteLine("Error 002");
                            Console.WriteLine("No se pudo leer correctamente, y no se va a facturar.");
                            
                        }
                        break;

                    case 4:

                        Console.WriteLine("\nLoading...\n");

                        //var customerUser = customerUserController.Read(userId);

                        bool canCompletePurchase = true;
                        if(customerUser != null)
                        {

                          

                            if (userWantsFacturar==true && customerUser.DefaultFiscalAdressId == null)
                            {
                                canCompletePurchase = false;
                                Console.WriteLine("El usuario desea facturar, pero falta direccion Fiscal.");

                                Console.WriteLine("Error 003");
                                


                            }
                            if (customerUser.DefaultDeliveryAdressId == null)
                            {
                                Console.WriteLine(  "Falta seleccionar Direccion de Envio.");
                                Console.WriteLine("Error 003");


                                canCompletePurchase = false;
                            }
                            if (customerUser.DefaultBankCardId == null)
                            {
                                Console.WriteLine("Falta seleccionar Tarjeta de Credito");

                                Console.WriteLine("Error 003");

                                canCompletePurchase = false;

                            }
                        }
                        else

                        {
                            Console.WriteLine("Fatal Error, Exit App. Log in again.");
                            canCompletePurchase =false;
                        }


                        if (canCompletePurchase == true && shoppingCartController.VerifyAvailableContents(userId))
                        {


                            var shoppingCartAnother = shoppingCartController.Index(userId);
                            double totalAnother = 0.0;
                            if (shoppingCartAnother is not null)
                                foreach (var item in shoppingCartAnother)
                                {
                                    
                                    totalAnother += item.Count * item.Product!.Price;

                                }

                            var myNewOrderHeader = OrderHeader.Create(userId, totalAnother, (int)customerUser!.DefaultDeliveryAdressId!, customerUser.DefaultFiscalAdressId);
                            var orderHeaderId = orderHeaderController.Create(myNewOrderHeader);
                            





                            if (shoppingCartAnother is not null)
                            foreach (var item in shoppingCartAnother)
                            {
                                    orderHeaderController.CreateDetails(OrderDetail.Create(orderHeaderId, item.Product!.Id,item.Count,item.Product.Price));
                                    productController.Update(item);


                            }

                            //orderHeaderController.Save();

                            
                            shoppingCart = shoppingCartController.Index(userId);

                            shoppingCartController.Remove(userId);


                            Console.WriteLine($"***************************************************************************************************************************");
                            Console.WriteLine($"*                                   COMPRA EXITOSA                                                                        *");

                            Console.WriteLine($"Ticket #: {orderHeaderId}");
                            Console.WriteLine($"Fecha: {myNewOrderHeader.OrderDate}");

                             total = 0.0;

                            if (shoppingCart is not null)
                                foreach (var item in shoppingCart)
                                {

                                    Console.WriteLine(item.ToStringCompraExitosa());
                                    total += item.Count * item.Product!.Price;
                                }

                            Console.WriteLine();
                            Console.WriteLine($"*Total de orden fue:                                                                                              ${total} ");

                            Console.WriteLine($"***************************************************************************************************************************");
                            Console.WriteLine("Compra realizada, revisar-> menu de Compras anteriores.");


                            return;
                        }
                        else
                        {
                            Console.WriteLine("Error 003");
                            AdressAndBankCustomerUserEditingView.Menu(db, userId);
                        }







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
