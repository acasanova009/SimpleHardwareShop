using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{

    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public abstract class ApplicationUser
    {


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }
        [Required]

        public string SecondLastName { get; set; }
        
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]

        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
        public string Password { get; set; }

       

       





        //public override string ToString()
        //{
        //    var basicInfo = $"[Application User] Id:{Id} Name: {Name} UserType:{UserType} UserName:{UserName}";

           


        //    basicInfo += "\n";

        //    if (BankCards is object)
        //    {
                
        //        foreach (var card in BankCards)
        //        {
        //            if (card.Id== DefaultBankCardId)
        //            {
        //                basicInfo += $"\n TC/TD: {card.ToString()} ";

        //            }
        //            else
        //            {
        //                basicInfo += card.ToString();

        //                basicInfo += "\n";
        //            }
        //        }
        //    }
        //    if (Adresses is object)
        //    {

        //        foreach (var a in Adresses)
        //        {

        //            if (a.Id == DefaultDeliveryAdressId)
        //            {
        //                basicInfo += $"\n Direccion de envio: {a.ToString()} ";

        //            }
                    
        //            if (a.Id == DefaultFiscalAdressId)
        //            {
        //                basicInfo += $"\n Direccion de facutracion: {a.ToString()} ";
        //            }
                    

        //            //basicInfo += a.ToString();

                    
                    
        //        }
        //        basicInfo += "\n";
        //    }

        //    return basicInfo;
        //}

        
        //public int? DefaultBankCardId { get; set; }

        ////[NotMapped]
        ////public BankCard? BankCard { get; set; }


        //public int? DefaultDeliveryAdressId { get; set; }
        ////[NotMapped]
        ////public Adress? DefaultDeliveryAdress { get; set; }

        //public int? DefaultFiscalAdressId { get; set; }
        ////[NotMapped]
        ////public Adress? DefaultFiscalAdress { get; set; }

        ////[NotMapped]
        ////[NotMapped]
        //public ICollection<Adress>? Adresses { get; set; }
        
        //public ICollection<BankCard>? BankCards { get; set; }
        ////[NotMapped]
        //public ICollection<OrderHeader>? OrderHeaders { get; set; }



    }
}
