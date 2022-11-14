using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Views.Creation
{
    public static class CustomerUserCreationView
    {

        public static CustomerUser Menu(CustomerUser? customer= null)
        {

            
            customer??= new CustomerUser();


            Console.WriteLine("Ingresar Nombre de pila");
            customer.Name = Console.ReadLine() ?? "Nombre default";

            Console.WriteLine("Ingresar Apellido Paterno");
            customer.LastName = Console.ReadLine() ?? "Apellido P default";


            Console.WriteLine("Ingresar Apellido Materno");
            customer.SecondLastName = Console.ReadLine() ?? "Apellido M default";

            Console.WriteLine("Ingresar USERNAME");
            customer.UserName = Console.ReadLine() ?? "Username error";

            Console.WriteLine("Ingresar email");
            customer.Email = Console.ReadLine() ?? "correo@gmail.com";


            customer.Password = "";
            while (customer.Password.Length <8)
            {

                Console.WriteLine("Ingresar contraseña de minimo 8 caracteres");
                customer.Password = Console.ReadLine() ?? "12345678";
                //customer.Account = customer.Account.Replace(" ", "");

            }




            return customer;

        }
    }
}
