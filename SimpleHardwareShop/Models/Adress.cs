﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{
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
