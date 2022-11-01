using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleHardwareShop.Models
{
    public class BankCard
    {

        public int Account { get; set; }
        public DateTime ExpirationDate { get; set; }

        //public int Year { get; set; }

        public int SecutiryCode { get; set; }

        public override string ToString()
        {
            return "BANK CARD: " + "Account: " + Account + " ExpirationDate:" + ExpirationDate;
        }


    }
}
