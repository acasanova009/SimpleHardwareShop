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
    public static class BankCardCretionView
    { 

        public static BankCard Menu(int userId)
        {
            BankCard card = new BankCard();

            try
            {

                card.ApplicationUserId = userId;

                Console.WriteLine("Ingresar 16 digitos de TC/TD: SIN ESPACIOS. ");
                
                card.Account = Console.ReadLine()??"";

                Console.WriteLine("Ingresar nombre de TC/TD ");

                card.Name = Console.ReadLine() ?? "";

                Console.WriteLine("Ingresar año de vencimiento eg. 2024.");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingresar mes de vencimiento eg. 08.");
                int month = Convert.ToInt32(Console.ReadLine());

                card.ExpirationDate = new DateTime(1, month, year);

                Console.WriteLine("Ingresar codigo de seguridad");
                card.SecurityCode = Convert.ToInt32(Console.ReadLine());


            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong format in TC/TD");

            }
                return card;

        }
    }

}