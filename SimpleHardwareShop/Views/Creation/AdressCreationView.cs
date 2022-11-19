using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
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

namespace SimpleHardwareShop.Views
{
    /// <summary>Class <c>AdressCreationView</c> Clase estática para crear una nueva dirección</summary>
    public static class AdressCreationView
    {


        

        public static Adress Create(int userId, bool isFiscalAdress = false, bool isCustomerAdress= true)
        {
            Console.Clear();


            Adress card = new();

            try
            {

                if (isCustomerAdress)
                {
                    card.CustomerUserId = userId;

                }
                else
                {

                    card.EmployeeUserId = userId;
                }

                Console.WriteLine("Ingresar dirección. Calle y número. ");

                card.StreetAdress = Console.ReadLine() ?? "";

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
                Console.WriteLine("Wrong format in Adress creation " + ex.ToString());



            }
            return card;

        }
    }
}
