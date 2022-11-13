using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{
    public class CustomerUser : ApplicationUser
    {

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


        public override string ToString()
        {
            var basicInfo = $"[Application User] Id:{Id} Name: {Name} UserName:{UserName}";




            basicInfo += "\n";

            if (BankCards is object)
            {

                foreach (var card in BankCards)
                {
                    if (card.Id == DefaultBankCardId)
                    {
                        basicInfo += $"\n TC/TD: {card.ToString()} ";

                    }
                    else
                    {
                        basicInfo += card.ToString();

                        basicInfo += "\n";
                    }
                }
            }
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

            return basicInfo;
        }

    }



}
