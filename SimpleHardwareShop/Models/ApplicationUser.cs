using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{
    public class ApplicationUser
    {


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }
        [Required]

        public string SecondLastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [Required]
        public Adress Adress { get; set; }

        //Fiscal Data

        public Adress FiscalAdress { get; set; }
        public string? RFC { get; set; }


        public override string ToString()
        {
            return "Name: "+ Name+" UserType:" + UserType+" UserName:" + UserName;
        }















    }
}
