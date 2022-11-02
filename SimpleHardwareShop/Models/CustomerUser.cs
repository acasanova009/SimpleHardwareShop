using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{
    public class ApplicationUserA : ApplicationUser
    {

        public int? DefaultBankCardId { get; set; }
        public BankCard? DefaultBankCard { get; set; }
        public int? DefaultDeliveryAdressId { get; set; }
        public Adress? DefaultDeliveryAdress { get; set; }

        public int? DefaultFiscalAdressId { get; set; }
        public Adress? DefaultFiscalAdress { get; set; }


        public ICollection<Adress>? Adresses { get; set; }  

        public ICollection<BankCard>? BankCards { get; set; }

        public ICollection<OrderHeader>? OrderHeaders { get; set; }


        public override string ToString()
        {
            return base.ToString();
        }

       
    }



}
