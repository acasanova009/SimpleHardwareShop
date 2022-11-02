using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Views
{
    public static class ApplicationUserCreationView
    { 

        public static ApplicationUser Menu()
        {
            ApplicationUser application = new ApplicationUser();

            
            Console.WriteLine("Ingresar Nombre de pila");
            application.Name = Console.ReadLine()?? "Nombre default";

            Console.WriteLine("Ingresar Apellido Paterno");
            application.LastName = Console.ReadLine() ?? "Apellido P default";


            Console.WriteLine("Ingresar USERNAME");
            application.SecondLastName = Console.ReadLine() ?? "Apellido M default";

            Console.WriteLine("Ingresar Apellido Materno");
            application.UserName = Console.ReadLine() ?? "Username error";

            Console.WriteLine("Ingresar email");
            application.Email = Console.ReadLine() ?? "correo@gmail.com";

            Console.WriteLine("Ingresar contraseña");
            application.Password = Console.ReadLine() ?? "123";

            application.UserType = UserType.Application;

            //application.AdressId = 1;
            //application.FiscalAdressId = 1;
            //application.RFC = "my favorite RFC";



            return application;

        }
    }
}
