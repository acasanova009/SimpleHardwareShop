using SimpleHardwareShop.Controller;
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

        public static Adress Menu(int userId,bool isFiscalAdress=false)
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
