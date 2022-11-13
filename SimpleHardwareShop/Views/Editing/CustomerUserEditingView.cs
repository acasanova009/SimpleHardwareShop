using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using SimpleHardwareShop.Views.Creation;
using System;



public static class CustomerUserEditingView
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

        var customer = customerUserController.Read(userId);



        bool salir = false;

        while (!salir)
        {

            try
            {

                Console.WriteLine("");
                Console.WriteLine("******************************************************");
                Console.WriteLine("1. Ver direcciones actuales.");
                Console.WriteLine("2. Ingresar nueva direccion.");
                Console.WriteLine("3. Seleccionar direccion de envio la-default.");
                Console.WriteLine("4. Seleccionar direccion fiscal  (opcional) la-default.");
                Console.WriteLine("5. Eliminar direccion.");

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("6. Ver tarjetas de credito actuales.");
                Console.WriteLine("7. Ingresar nueva tarjeta de credito.");
                Console.WriteLine("8. Seleccionar tarjeta de credito.");
                

                Console.WriteLine("******************************************************");
                Console.WriteLine("0. Regresar");
                Console.WriteLine("******************************************************");

                Console.WriteLine("");


                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        adressController.Index(userId);


                        


                        break;

                    case 2:

                        Console.WriteLine("Queire ingresar direccion fiscal? Escribir 1.");
                        var fiscal = Console.ReadLine();

                        if (fiscal is object && fiscal.Equals("1"))
                        {

                            
                          var fiscalId = adressController.Create(AdressCreationView.Create(userId, true));
                            customer!.DefaultFiscalAdressId = fiscalId;
                            applicationUserController.Update(customer);

                        }
                        else
                        {

                           var delId = adressController.Create(AdressCreationView.Create(userId, false));
                            customer!.DefaultDeliveryAdressId = delId;
                            applicationUserController.Update(customer);
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
                            Console.WriteLine("Ingresar correctamente el id de la direccion.");

                        }



                        break;
                    case 4:

                        try
                        {
                            Console.WriteLine("Ingresar id de direccion.");
                            int adressid = Convert.ToInt32(Console.ReadLine());
                            customerUserController.UpdateFiscalAdress(userId, adressid);
                            

                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Ingresar correctamente el id de la direccion.");
                        }



                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine("Ingresar id de direccion a eliminar");
                            int adressid = Convert.ToInt32(Console.ReadLine());
                            var adressToRemove = adressController.Read(userId,adressid);
                            if (adressToRemove is object)
                            {
                                adressController.Remove(adressToRemove);

                            }


                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Ingresar correctamente el id de la direccion.");
                        }

                        break;
                    case 6:

                        bankCardController.Index(userId);

                        break;
                    case 7:


                        bankCardController.Create(BankCardCretionView.Menu(userId));
                        





                        break;
                    case 8:

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
