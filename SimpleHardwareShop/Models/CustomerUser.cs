 using System;
using System.Collections.Generic;
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

namespace SimpleHardwareShop.Models
{
    /// <summary>Modelo-Entidad para CustomerUser</summary>
    public class CustomerUser : ApplicationUser
    {
        //public bool  { get; set; }
        public int? DefaultBankCardId { get; set; }

        //[NotMapped]
        //public BankCard? BankCard { get; set; }


        public int? DefaultDeliveryAdressId { get; set; }
        //[NotMapped]
        //public Adress? DefaultDeliveryAdress { get; set; }

        public int? DefaultFiscalAdressId { get; set; }
        //[NotMapped]
        //public Adress? DefaultFiscalAdress { get; set; }

        //[NotMapped]
        //[NotMapped]
        public ICollection<Adress>? Adresses { get; set; }

        public ICollection<BankCard>? BankCards { get; set; }
        //[NotMapped]
        public ICollection<OrderHeader>? OrderHeaders { get; set; }


        public string ToStringResumenCompras()
        {
            //Call in resumen de compras.
            var basicInfo = $"[Application User] Id:{Id} NombreUsuario:{UserName}";
            basicInfo += "\n";
            basicInfo += $"Nombre:           {Name}";
            basicInfo += "\n";
            basicInfo += $"Apellido Paterno: {LastName}";
            basicInfo += "\n";
            basicInfo += $"Apellido Materno: {SecondLastName}";
            basicInfo += "\n";
            basicInfo += $"Correo:           {Email}";





            basicInfo += "\n";

            if (BankCards is object)
            {

                foreach (var card in BankCards)
                {
                    if (card.Id == DefaultBankCardId)
                    {
                        basicInfo += $"\n Default Bank Card: {card.ToString()} ";

                    }
                    //else
                    //{
                    //    basicInfo += card.ToString();

                    //    basicInfo += "\n";
                    //}
                }
            }
            else
            {
                basicInfo += "No hay tarjetas de credito registradas.";
            }
            basicInfo += "\n";
            basicInfo += "\n";
            if (Adresses is object)
            {

                foreach (var a in Adresses)
                {

                    if (a.Id == DefaultDeliveryAdressId)
                    {
                        basicInfo += $"\n Direccion de envio: {a.ToString()} ";

                    }

                    if (a.Id == DefaultFiscalAdressId)
                    {
                        basicInfo += $"\n Direccion de facutracion: {a.ToString()} ";
                    }


                    //basicInfo += a.ToString();



                }
                basicInfo += "\n";
            }
            else
            {
                basicInfo += "No hay direcciones registradas.";
            }

            return basicInfo;
        }

        public override string ToString()
        {
            //Call in resumen de compras.
           
            var basicInfo = $"[Application User] Id:{Id} NombreUsuario:{UserName}";
            basicInfo += "\n";
            basicInfo += $"Nombre:           {Name}";
            basicInfo += "\n";
            basicInfo += $"Apellido Paterno: {LastName}";
            basicInfo += "\n";
            basicInfo += $"Apellido Materno: {SecondLastName}";
            basicInfo += "\n";
            basicInfo += $"Correo:           {Email}";

            basicInfo += "\n";


            basicInfo += "\n";

            if (BankCards is object)
            {

                basicInfo += "Tarjetas de credito/debito:";
                basicInfo += "\n";

                foreach (var card in BankCards)
                {
                    if (card.Id == DefaultBankCardId)
                    {
                        basicInfo += $"\n Default Bank Card: {card.ToString()} ";

                    }
                    else
                    {
                        basicInfo += $"\n Otras Bank Card: {card.ToString()} ";
                    }
                    
                }
            }
           
            basicInfo += "\n";
            
            basicInfo += "\n";
            if (Adresses is object)
            {

                basicInfo += "Direcciones registradas:";
                basicInfo += "\n";
                foreach (var a in Adresses)
                {

                    if (a.Id == DefaultDeliveryAdressId)
                    {
                        basicInfo += $"\n Direccion de envio default: {a.ToString()} ";

                    }else 

                    if (a.Id == DefaultFiscalAdressId)
                    {
                        basicInfo += $"\n Direccion de facutracion default: {a.ToString()} ";
                    }
                    else
                    {
                        basicInfo += $"\n Otras direcciones: {a.ToString()} ";
                    }
                    

                    //basicInfo += a.ToString();



                }
                basicInfo += "\n";
            }

            return basicInfo;
        }

    }



}
