using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Views.Creation
{
    public static class EmployeeUserCreationView
    {

        public static EmployeeUser Menu()
        {
            EmployeeUser employee = new EmployeeUser();


            Console.WriteLine("Ingresar Nombre de pila");
            employee.Name = Console.ReadLine() ?? "Nombre default";

            Console.WriteLine("Ingresar Apellido Paterno");
            employee.LastName = Console.ReadLine() ?? "Apellido P default";


            Console.WriteLine("Ingresar Apellido Materno");
            employee.SecondLastName = Console.ReadLine() ?? "Apellido M default";

            Console.WriteLine("Ingresar USERNAME");
            employee.UserName = Console.ReadLine() ?? "Username error";

            Console.WriteLine("Ingresar email");
            employee.Email = Console.ReadLine() ?? "correo@gmail.com";

            employee.Password = "";
            while (employee.Password.Length < 8)
            {

                Console.WriteLine("Ingresar contraseña de minimo 8 caracteres");
                employee.Password = Console.ReadLine() ?? "12345678";
                //customer.Account = customer.Account.Replace(" ", "");

            }



            employee.EmployeeType = EmployeeType.Employee;

            


            try
            {
                Console.WriteLine("Tipo de emplado");
                Console.WriteLine("1. Empleado normal");
                Console.WriteLine("2. Gerente");
                Console.WriteLine("3. CFO");

                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Seleccion final es Empleado Normal");
                        employee.EmployeeType = EmployeeType.Employee;
                        break;

                    case 2:
                        Console.WriteLine("Seleccion final es Gerente");
                        employee.EmployeeType = EmployeeType.Manager;
                        break;

                    case 3:
                        Console.WriteLine("Seleccion final es CFO");
                        employee.EmployeeType = EmployeeType.CFO;
                        break;

                    default:
                        employee.EmployeeType = EmployeeType.Employee;
                        Console.WriteLine("Se selecciono automaticamente Empleado normal");
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }





            return employee;

        }
    }
}
