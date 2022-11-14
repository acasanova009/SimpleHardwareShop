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
        public int Id { get; set; }

        public string? Name { get; set; } //EG. My Favorite Credit Card.  or BlackCardOnlyVacations

        public int CustomerUserId { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
        public string Account { get; set; }
        public DateTime ExpirationDate { get; set; }

        //public int Year { get; set; }
        public string SecurityCode { get; set; }


        public override string ToString()
        {
            return $"[BankCard] Id: {Id} Name: {Name} Account: {Account}";
        }


    }
}
