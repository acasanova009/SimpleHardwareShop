using Microsoft.EntityFrameworkCore.Query.Internal;
using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using SimpleHardwareShop.Views.Creation;
//using System;



public static class InteractiveOrderHeaderView
{

    public static HardwareShopContext _db { get; set; }
    //private ProductController _productController { get; set; }
    //private ShoppingCartController _shoppingCartController { get; set; }
    //private ApplicationUserController applicationUserController { get; set; }

    //private ApplicationUser? _activeUser { get; set; }
    //public ApplicationUserInteractiveView(HardwareShopContext db)
    //{
    //}

    //private ShoppingCartController _shoppingCartController { get; set; }


    public static void Menu(HardwareShopContext db,int userId)
	{
        //_db = db;
        //var _shoppingCartController = new ShoppingCartController(db);
        //var _orderHeaderController = new OrderHeaderController(db);
        //var customerUserController = new CustomerUserController(db);
        //var bankCardController = new BankCardController(db);
        //var adressController = new AdressController(db);

        Console.Clear();


        var productController = new ProductController(db);
        var applicationUserController = new ApplicationUserController(db);
        var customerUserController = new CustomerUserController(db);
        var orderHeaderController = new OrderHeaderController(db);
        var shoppingCartController = new ShoppingCartController(db);


        bool userWantsFacturar = false;



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

                        

                        CustomerUserEditingView.Menu(db, userId);

                        


                        break;


                    case 2:

                        Console.WriteLine($"+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine($"+                                   Resumen de la compra                                                                  +");
                        Console.WriteLine($"+-------------------------------------------------------------------------------------------------------------------------+");
                        Console.WriteLine($"+                                   Informacion Cliente                                                                   +");

                        var user = customerUserController.Read(userId);


                        Console.WriteLine(user.ToStringResumenCompras());
                        Console.WriteLine($"+-------------------------------------------------------------------------------------------------------------------------+");
                        Console.WriteLine($"+                                  Ariticulos por comprar                                                                 +");

                        var shoppingCart = shoppingCartController.Index(userId);
                        double total = 0.0;

                        if(shoppingCart is object)
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
                            Console.WriteLine("No se pudo leer correctamente, y no se va a facturar.");
                            
                        }
                        break;

                    case 4:


                        var userr = customerUserController.Read(userId);

                        bool canCompletePurchase = true;
                        if(userr != null)
                        {

                          

                            if (userWantsFacturar==true && userr.DefaultFiscalAdressId == null)
                            {
                                canCompletePurchase = false;
                                Console.WriteLine("El usuario desea facturar, pero falta direccion Fiscal.");
                                

                                


                            }
                            if (userr.DefaultDeliveryAdressId == null)
                            {
                                Console.WriteLine(  "Falta seleccionar Direccion de Envio.");
                                

                                canCompletePurchase = false;
                            }
                            if (userr.DefaultBankCardId == null)
                            {
                                Console.WriteLine("Falta seleccionar Tarjeta de Credito");
                                

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
                            if (shoppingCartAnother is object)
                                foreach (var item in shoppingCartAnother)
                                {
                                    
                                    totalAnother += item.Count * item.Product!.Price;

                                }

                            var myNewOrderHeader = OrderHeader.Create(userId, totalAnother, (int)userr!.DefaultDeliveryAdressId!, userr.DefaultFiscalAdressId);
                            var orderHeaderId = orderHeaderController.Create(myNewOrderHeader);
                            





                            if (shoppingCartAnother is object)
                            foreach (var item in shoppingCartAnother)
                            {
                                    orderHeaderController.CreateDetails(OrderDetail.Create(orderHeaderId, item.Product!.Id,item.Count,item.Product.Price));
                                    productController.Update(item);


                            }

                            orderHeaderController.Save();

                            
                            shoppingCart = shoppingCartController.Index(userId);

                            shoppingCartController.Remove(userId);


                            Console.WriteLine($"***************************************************************************************************************************");
                            Console.WriteLine($"*                                   COMPRA EXITOSA                                                                        *");
                           

                             total = 0.0;

                            if (shoppingCart is object)
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
                            CustomerUserEditingView.Menu(db, userId);
                        }







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
