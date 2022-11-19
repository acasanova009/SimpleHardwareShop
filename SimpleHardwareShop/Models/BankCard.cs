using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

    /// <summary>Modelo-Entidad para BankCard</summary>
    public class BankCard
    {
        public int Id { get; set; }

        public string? Name { get; set; } //EG. My Favorite Credit Card.  or BlackCardOnlyVacations

        public int CustomerUserId { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
        public string Account { get; set; }
        public DateTime? ExpirationDate { get; set; }

        //public int Year { get; set; }
        public string SecurityCode { get; set; }


        public override string ToString()
        {
            return $"[BankCard] Id: {Id} Name: {Name} Account: {Account} + {ExpirationDate}";
        }


    }
}
