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
        //var _productController = new ProductController(db);
        //var _shoppingCartController = new ShoppingCartController(db);
        var _orderHeaderController = new OrderHeaderController(db);
        var applicationUserController = new ApplicationUserController(db);

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
                            applicationUserController.UpdateDeliveryAdress(userId, adressid);

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
                            applicationUserController.UpdateFiscalAdress(userId, adressid);
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
                            applicationUserController.UpdateDefaultCard(userId,cardId);

                        }
                        catch (Exception)
                        {


                        }

                        break;

                    case 8:

                        var user = applicationUserController.Read(userId);
                        
                        
                        var shoppingCart = shoppingCartController.Index(userId);
                        double total = 0.0;
                        if(shoppingCart is object)
                        foreach (var item in shoppingCart)
                            total += item.Count * item.Product!.Price;
                        


                        Console.Write(user);




                        break;
                    case 9:



                        var userr = applicationUserController.Read(userId);

                        bool canCompletePurchase = true;
                        if(userr != null)
                        {

                            if (userWantsFacturar==true && userr.DefaultFiscalAdressId == null)
                                canCompletePurchase = false;
                            if (userr.DefaultDeliveryAdressId == null)
                                canCompletePurchase = false;
                            if (userr.DefaultBankCardId == null)
                                canCompletePurchase = false;
                        }


                        if (canCompletePurchase == true)
                        {
                            var shoppingCartAnother = shoppingCartController.Index(userId);
                            double totalAnother = 0.0;
                            if (shoppingCartAnother is object)
                                foreach (var item in shoppingCartAnother)
                                {
                                    
                                    totalAnother += item.Count * item.Product!.Price;

                                }   
                            OrderHeader oh = orderHeaderController.Create(new OrderHeader(userId, totalAnother, (int)userr!.DefaultDeliveryAdressId!, userr.DefaultFiscalAdressId));
                            //orderHeaderController.Read();



                            if (shoppingCartAnother is object)
                            foreach (var item in shoppingCartAnother)
                            {
                                    orderHeaderController.CreateDetails(new OrderDetail(oh.Id,item.Product!.Id,item.Count,item.Product.Price));


                            }


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
