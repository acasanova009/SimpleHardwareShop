using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using System;



public static class OrderHeaderInteractiveView
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
        var productController = new ProductController(db);
        //var _shoppingCartController = new ShoppingCartController(db);
        var _orderHeaderController = new OrderHeaderController(db);
        var applicationUserController = new ApplicationUserController(db);
        var customerUserController = new CustomerUserController(db);

        var adressController = new AdressController(db);

        var bankCardController = new BankCardController(db);

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
                Console.WriteLine("1. Ver direcciones actuales.");
                Console.WriteLine("2. Ingresar nueva direccion.");
                Console.WriteLine("3. Seleccionar direccion de envio la-default");
                Console.WriteLine("4. Seleccionar direccion fiscal  (opcional) la-default");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("5. Ver tarjetas de credito actuales.");
                Console.WriteLine("6. Ingresar nueva tarjeta de credito.");
                Console.WriteLine("7. Seleccionar tarjeta de credito.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("8. Revisar detalles de compra.");
                Console.WriteLine("9. Confirmar compra.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("10. Regresar");
                Console.WriteLine("******************************************************");

                Console.WriteLine("");


                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        adressController.Index(userId);


                        //applicationUserController.UpdateApplication(activeUser, AdressCreationView.Menu(activeUser.Id, true));


                        break;

                    case 2:

                        Console.WriteLine("Queire ingresar direccion fiscal? Escribir 1.");
                        var fiscal = Console.ReadLine();

                        if (fiscal is object && fiscal.Equals("1"))
                        {
                            
                            adressController.Create(AdressCreationView.Create(userId, false));
                        }
                        else
                        {

                            adressController.Create(AdressCreationView.Create(userId, false));
                        }





                        break;

                    case 3:

                        try
                        {
                            Console.WriteLine("Ingresar id de direccion.");
                            int adressid = Convert.ToInt32(Console.ReadLine());
                            customerUserController.UpdateDeliveryAdress(userId, adressid);

                        }
                        catch (Exception)
                        {

                            
                        }



                        break;
                    case 4:

                        try
                        {
                            Console.WriteLine("Ingresar id de direccion.");
                            int adressid = Convert.ToInt32(Console.ReadLine());
                            customerUserController.UpdateFiscalAdress(userId, adressid);
                            userWantsFacturar = true;

                        }
                        catch (Exception)
                        {


                        }



                        break;
                    case 5:

                        bankCardController.Index(userId);

                        break;
                    case 6:


                        bankCardController.Create(BankCardCretionView.Menu(userId));
                        





                        break;
                    case 7:

                        try
                        {
                            Console.WriteLine("Ingresar id de TC/TD.");
                            int cardId = Convert.ToInt32(Console.ReadLine());
                            customerUserController.UpdateDefaultCard(userId,cardId);

                        }
                        catch (Exception)
                        {


                        }

                        break;

                    case 8:

                        Console.WriteLine($"***************************************************************************************************************************");
                        Console.WriteLine($"*                                   Resumen de la compra                                                                  *");
                        Console.WriteLine($"*-------------------------------------------------------------------------------------------------------------------------*");
                        Console.WriteLine($"*                                   Informacion Cliente                                                                   *");

                        var user = applicationUserController.Read(userId);


                        Console.WriteLine(user);
                        Console.WriteLine($"*-------------------------------------------------------------------------------------------------------------------------*");
                        Console.WriteLine($"*                                  Ariticulos por comprar                                                                 *");

                        var shoppingCart = shoppingCartController.Index(userId);
                        double total = 0.0;

                        if(shoppingCart is object)
                        foreach (var item in shoppingCart)
                        {

                            Console.WriteLine(item);
                            total += item.Count * item.Product!.Price;
                        }

                        Console.WriteLine();
                        Console.WriteLine($"*Precio TOTAL es:                                                                                              ${total} ");

                        Console.WriteLine($"***************************************************************************************************************************");








                        break;
                    case 9:



                        var userr = applicationUserController.Read(userId);

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

                            
                            shoppingCartController.Remove(userId);
                            Console.WriteLine("Compra realizada, revisar-> menu de Compras anteriores.");
                            return;
                        }







                        break;

                    case 10:
                        salir = true;

                        break;
                    default:
                        Console.WriteLine("Elige una opcion entre 1 y 6");
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
