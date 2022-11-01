using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{
    public class Adress
    {
       
        [Required]
        public string StreetAdress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int PostalCode { get; set; }

        //public string City { get; set; }
        //[Required]
        //public string State { get; set; }
        //[Required]

        public override string ToString()
        {
            return "Adress:"+StreetAdress+" P.C. "+PostalCode + "Phone:" + PhoneNumber;
        }
    }
}
