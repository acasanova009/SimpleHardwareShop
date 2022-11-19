using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    /// <summary>Modelo-Entidad para Adress</summary>
    public class Adress
    {
       
        [Required]
        public int Id { get; set; }

        //public int ApplicationUserId { get; set; }

        public int? CustomerUserId { get; set; }

        public int? EmployeeUserId { get; set; }

        [Required]
        public string StreetAdress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? AdditionalInformation { get; set; }

        
        public int PostalCode { get; set; }

        public string? RFC { get; set; }



        //public string City { get; set; }
        //[Required]
        //public string State { get; set; }
        //[Required]

        public override string ToString()
        {
            string rfcString = "";
            if (RFC is not null)
            {

                rfcString = $" RFC: {RFC}";
            }
            return $"[Adress]: Id: {Id}  {StreetAdress}  P.C. {PostalCode}  Phone: {PhoneNumber}" + rfcString;
        }
    }
}
