using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
  Equipo Individual
*/
/*

  Codigo por: Gonzalez Casanova Gallegos Renato Alfonso
  

  Fecha de cración: 19/Nov/2022

  Comentario General: Este programa simula una tienda de productos de hardware, que se conecta directamente con bases de datos.

*/

namespace SimpleHardwareShop.Views.Creation
{
    public static class BankCardCretionView
    {

        /// <summary>Class <c>BankCardCretionView</c> Clase estática para crear una nueva tarjeta bancaria</summary>
        public static BankCard Menu(int userId, bool isCreditCard = true)
        {
            Console.Clear();

            BankCard card = new();

            try
            {
                Console.WriteLine("Ingresar nombre de TC/TD ");

                card.Name = Console.ReadLine() ?? "";

                card.CustomerUserId = userId;


                card.Account = "";
                while (card.Account.Length != 16)
                {

                    Console.WriteLine("Ingresar 16 digitos de TC/TD:  ");
                    card.Account = Console.ReadLine() ?? "";
                    card.Account = card.Account.Replace(" ", "");


                    if (card.Account.Length != 16)
                    {
                        Console.WriteLine("Error 012");

                    }


                }



                if (isCreditCard)
                {

                    Console.WriteLine("Ingresar año de vencimiento eg. 2024.");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresar mes de vencimiento para sep eg. 9.");
                    int month = Convert.ToInt32(Console.ReadLine());

                    card.ExpirationDate = new DateTime(year, month, 1);

                }
                else
                {
                    card.ExpirationDate = null;
                }

                card.SecurityCode = "";
                while (card.SecurityCode.Length != 3)
                {

                    Console.WriteLine("Ingresar codigo de seguridad");
                    card.SecurityCode = Console.ReadLine() ?? "";
                    card.SecurityCode = card.SecurityCode.Replace(" ", "");

                    if (card.SecurityCode.Length !=3)
                    {
                        Console.WriteLine("Error 011");

                    }

                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Wrong format in TC/TD");

            }
            return card;

        }
    }

}