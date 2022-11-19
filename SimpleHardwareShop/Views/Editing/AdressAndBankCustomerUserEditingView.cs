using SimpleHardwareShop.Controller;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;
using System;

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
    public static class AdressAndBankCustomerUserEditingView
    {


        /// <summary>Class <c>AdressAndBankCustomerUserEditingView</c> Clase estática para editar datos especificos del cliente</summary>
        public static void Menu(HardwareShopContext db, int userId)
        {
            //Console.Clear();
            var productController = new ProductController(db);
            var _orderHeaderController = new OrderHeaderController(db);
            var customerUserConstroller = new CustomerUserController(db);

            var adressController = new AdressController(db);

            var bankCardController = new BankCardController(db);

            var orderHeaderController = new OrderHeaderController(db);

            var shoppingCartController = new ShoppingCartController(db);



            var customer = customerUserConstroller.Read(userId);



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
                    Console.WriteLine("6. Ver tarjetas actuales.");
                    Console.WriteLine("7. Ingresar nueva tarjeta.");
                    Console.WriteLine("8. Seleccionar tarjeta.");


                    Console.WriteLine("******************************************************");
                    Console.WriteLine("0. Regresar");
                    Console.WriteLine("******************************************************");

                    Console.WriteLine("");


                    Console.WriteLine("Elige una de las opciones");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:

                            var direcciones = adressController.Index(userId);
                            if (direcciones is not null && direcciones.Count > 0)
                            {
                                direcciones.ForEach(s => Console.WriteLine(s));

                            }
                            else
                            {
                                
                                Console.WriteLine("No hay direcciones registradas.");
                            }




                            break;

                        case 2:

                            Console.WriteLine("Queire ingresar direccion fiscal? Escribir 1.");
                            var fiscal = Console.ReadLine();

                            if (fiscal is not null && fiscal.Equals("1"))
                            {


                                var fiscalId = adressController.Create(AdressCreationView.Create(userId, true));
                                customer!.DefaultFiscalAdressId = fiscalId;
                                customerUserConstroller.Update(customer);

                            }
                            else
                            {

                                var delId = adressController.Create(AdressCreationView.Create(userId, false));
                                customer!.DefaultDeliveryAdressId = delId;
                                customerUserConstroller.Update(customer);
                            }





                            break;

                        case 3:

                            try
                            {
                                Console.WriteLine("Ingresar id de direccion.");
                                int adressid = Convert.ToInt32(Console.ReadLine());
                                customerUserConstroller.UpdateDeliveryAdress(userId, adressid);

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error 007");
                                Console.WriteLine("Ingresar correctamente el id de la direccion.");

                            }



                            break;
                        case 4:

                            try
                            {
                                Console.WriteLine("Ingresar id de direccion.");
                                int adressid = Convert.ToInt32(Console.ReadLine());
                                customerUserConstroller.UpdateFiscalAdress(userId, adressid);


                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Error 007");
                                Console.WriteLine("Ingresar correctamente el id de la direccion.");
                            }



                            break;
                        case 5:
                            try
                            {
                                Console.WriteLine("Ingresar id de direccion a eliminar");
                                int adressid = Convert.ToInt32(Console.ReadLine());
                                var adressToRemove = adressController.Read(userId, adressid);
                                if (adressToRemove is not null)
                                {
                                    adressController.Remove(adressToRemove);

                                }
                                else
                                {
                                    Console.WriteLine("Error 007");
                                    Console.WriteLine("Direccion de envio no existe, ingresar Id correcto");
                                }


                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Ingresar correctamente el id de la direccion.");
                            }

                            break;
                        case 6:

                            var bankCards = bankCardController.Index(userId);
                            if (bankCards is not null && bankCards.Count > 0)
                            {
                                bankCards.ForEach(s => Console.WriteLine(s));
                            }
                            else
                            {
                                Console.WriteLine("No hay tarjetas de credito registradas.");

                            }

                            break;
                        case 7:

                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Seleccionar tipo de tarjeta deseada");
                                Console.WriteLine("1. Ingresar targejeta de Credito");
                                Console.WriteLine("2. Ingresar targejeta de Debito");
                                int option = Convert.ToInt32(Console.ReadLine());
                                BankCard? bankCard = null;
                                if (option == 1)
                                {

                                    bankCard = BankCardCretionView.Menu(userId, true);
                                }
                                else
                                {
                                    bankCard = BankCardCretionView.Menu(userId, false);
                                }
                                

                                    var bankId = bankCardController.Create(bankCard);
                                    customer!.DefaultBankCardId = bankId;
                                    customerUserConstroller.Update(customer);

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error 007");
                                Console.WriteLine("No se ingreso una opcion correctamente, intentar de nuevo.");
                            }







                            break;
                        case 8:

                            try
                            {
                                Console.WriteLine("Ingresar id de TC/TD.");
                                int cardId = Convert.ToInt32(Console.ReadLine());
                                customerUserConstroller.UpdateDefaultCard(userId, cardId);

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error 007");
                                Console.WriteLine("No se ingreso una opcion correctamente, intentar de nuevo.");

                            }

                            break;





                        case 0:
                            Console.WriteLine("Has elegido regresar");
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Elige una opcion del menu");
                            Console.WriteLine("Error 001");
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
}