using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{
    public class NormalUser : ApplicationUser
    {
        public BankCard? TarjetaBancaria { get; set; }


        public override string ToString()
        {
            return "NORMAL USER: " + base.ToString();
        }
    }

}
