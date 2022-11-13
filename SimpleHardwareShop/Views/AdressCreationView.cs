using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Views
{
    public static class AdressCreationView
    { 

        
        public static void Menu(HardwareShopContext db, int userId)
        {
            var applicationUserController = new ApplicationUserController(db);
            var customerUserController = new CustomerUserController(db);
            var adressController = new AdressController(db);

            

            try
            {
                Console.WriteLine("1. Ver direcciones actuales.");
                Console.WriteLine("2. Ingresar nueva direccion.");
                Console.WriteLine("3. Seleccionar direccion de envio la-default");
                Console.WriteLine("4. Seleccionar direccion fiscal  (opcional) la-default");


                
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
                            

                        }
                        catch (Exception)
                        {


                        }



                        break;
                    
                    default:
                        //Console.WriteLine("");
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }           

        public static Adress Create(int userId,bool isFiscalAdress=false)
        {
            Adress card = new Adress();

            try
            {

                card.ApplicationUserId = userId;

                Console.WriteLine("Ingresar dirección. Calle y número. ");
                
                card.StreetAdress = Console.ReadLine()??"";

                Console.WriteLine("Ingresar código postal. ");

                card.PostalCode = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingresar telefono de contacto. ");

                card.PhoneNumber = Console.ReadLine() ?? "";

                Console.WriteLine("Ingresar información adicional (Opcional) ");

                card.AdditionalInformation = Console.ReadLine() ?? "";

                if (isFiscalAdress)
                {
                    Console.WriteLine("Ingresar información de RFC ");

                    card.RFC = Console.ReadLine() ?? "";

                }


               

            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong format in Adress creation");

            }
                return card;

        }
    }
}
